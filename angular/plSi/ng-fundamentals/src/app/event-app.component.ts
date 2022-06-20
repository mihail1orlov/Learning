import { Component } from '@angular/core';
import { EventsListComponent } from "./events/events-list.component";

@Component({
  selector: 'event-app',
  templateUrl: './event-app.component.html',
  styleUrls: ['./event-app.component.css']
})
export class EventAppComponent {
  title = 'ng-fundamentals';
}
