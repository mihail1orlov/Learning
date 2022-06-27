import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { EventAppComponent } from './event-app.component';
import { EventThumbnail } from './events/event-thumbnail.component';
import { EventsListComponent } from './events/events-list.component';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
  imports: [
    BrowserModule
  ],
  declarations: [
    EventAppComponent,
    EventsListComponent,
    EventThumbnail,
    NavbarComponent
  ],
  providers: [],
  bootstrap: [EventAppComponent]
})
export class AppModule { }
