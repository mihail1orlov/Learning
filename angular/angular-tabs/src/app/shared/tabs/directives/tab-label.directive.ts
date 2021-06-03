import { Directive, TemplateRef } from '@angular/core';

@Directive({
  selector: '[appTabLabel]'
})
export class TabLabelDirective {

  constructor(private templateRef: TemplateRef<HTMLElement>) {
  }

  getTemplateRef(): TemplateRef<HTMLElement> {
    return this.templateRef;
  }

}
