import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
    selector: 'event-thumbnail',
    templateUrl: 'event-thumbnail.component.html'
})

export class EventThumbnail{
    @Input() event:any
    @Output() eventClick = new EventEmitter()
    
    handleClickMe(){
        console.log('clicked')
        this.eventClick.emit(this.event.name)
    }
}