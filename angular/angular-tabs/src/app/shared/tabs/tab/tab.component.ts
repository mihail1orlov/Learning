import {
  AfterContentInit,
  Component, ContentChild,
  ContentChildren,
  HostBinding,
  Input,
  OnChanges,
  OnDestroy,
  OnInit, QueryList,
  SimpleChanges
} from '@angular/core';
import { TabsService } from '../tabs.service';
import { Subject } from 'rxjs';
import { startWith, takeUntil } from 'rxjs/operators';
import { TabLabelDirective } from '../directives/tab-label.directive';
import { TabContentDirective } from '../directives/tab-content.directive';

@Component({
  selector: 'app-tab',
  templateUrl: './tab.component.html',
  styleUrls: ['./tab.component.scss']
})
export class TabComponent implements OnInit, OnChanges, OnDestroy, AfterContentInit {

  @ContentChild(TabContentDirective) private tabContent: TabContentDirective;
  @ContentChildren(TabLabelDirective) private tabLabels: QueryList<TabLabelDirective>;
  @HostBinding('class.active') private active: boolean;
  @Input() label: string;

  private index: number;

  private destroy$ = new Subject();

  constructor(private tabsService: TabsService) { }

  ngOnInit(): void {
    this.index = this.tabsService.getIndex();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.updateLabel();
  }

  private updateLabel(): void {
    if (this.index === undefined) {
      return;
    }

    const label = this.tabLabels?.first?.getTemplateRef() || this.label;
    this.tabsService.setLabel(this.index, label);
  }

  ngAfterContentInit(): void {
    this.tabLabels.changes.pipe(
      startWith(this.tabLabels),
      takeUntil(this.destroy$)
    ).subscribe(() => this.updateLabel());

    this.tabsService.getActiveIndex().pipe(
      takeUntil(this.destroy$)
    ).subscribe(activeIndex => {
      this.active = this.index === activeIndex;
      this.active ? this.tabContent?.render() : this.tabContent?.destroy();
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
