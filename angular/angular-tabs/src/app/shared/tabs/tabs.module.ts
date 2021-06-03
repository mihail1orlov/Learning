import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabsGroupComponent } from './tabs-group/tabs-group.component';
import { TabComponent } from './tab/tab.component';
import { TabLabelDirective } from './directives/tab-label.directive';
import { TabContentDirective } from './directives/tab-content.directive';


@NgModule({
  declarations: [TabsGroupComponent, TabComponent, TabLabelDirective, TabContentDirective],
  exports: [
    TabsGroupComponent,
    TabComponent,
    TabLabelDirective,
    TabContentDirective
  ],
  imports: [
    CommonModule
  ]
})
export class TabsModule {
}
