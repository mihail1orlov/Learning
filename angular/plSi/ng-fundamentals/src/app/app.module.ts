import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { EventAppComponent } from './event-app.component';

@NgModule({
  declarations: [
    EventAppComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [EventAppComponent]
})
export class AppModule { }
