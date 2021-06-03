import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IsStringPipe } from './is-string.pipe';



@NgModule({
    declarations: [
        IsStringPipe
    ],
    exports: [
        IsStringPipe
    ],
    imports: [
        CommonModule
    ]
})
export class PipesModule { }
