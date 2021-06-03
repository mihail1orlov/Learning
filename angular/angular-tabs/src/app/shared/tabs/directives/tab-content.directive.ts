import { Directive, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appTabContent]'
})
export class TabContentDirective {

  constructor(
    private templateRef: TemplateRef<HTMLElement>,
    private viewContainerRef: ViewContainerRef
  ) { }

  render(): void {
    this.viewContainerRef.createEmbeddedView(this.templateRef);
  }

  destroy(): void {
    this.viewContainerRef.clear();
  }
}
