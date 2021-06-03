import { Injectable, TemplateRef } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { TabLabel } from './tab-label';

@Injectable()
export class TabsService {

  private index = 0;
  private labels$ = new BehaviorSubject<TabLabel[]>([]);
  private activeIndex$ = new BehaviorSubject<number>(0);

  constructor() { }

  getIndex(): number {
    return this.index ++;
  }

  setLabel(index: number, label: string | TemplateRef<HTMLElement>): void {
    const labels = this.labels$.value;
    if (label instanceof TemplateRef) {
      labels[index] = { templateRef: label };
    } else {
      labels[index] = { stringValue: label };
    }

    this.labels$.next(labels);
  }

  getLabels(): Observable<TabLabel[]> {
    return this.labels$.asObservable();
  }

  setActiveIndex(index: number): void {
    this.activeIndex$.next(index);
  }

  getActiveIndex(): Observable<number> {
    return this.activeIndex$.asObservable();
  }
}
