import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { EventAppComponent } from './event-app.component';
import { EventsListComponent } from './events/events-list.component';

@NgModule({
  imports: [
    BrowserModule
  ],
  declarations: [
    EventAppComponent,
    EventsListComponent
  ],
  providers: [],
  bootstrap: [EventAppComponent]
})
export class AppModule { }
