import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
    selector: 'event-thumbnail',
    templateUrl: 'event-thumbnail.component.html',
    styleUrls: ['event-thumbnail.component.css']
})

export class EventThumbnail {
    @Input() event: any
    @Output() eventClick = new EventEmitter()

    
    private _someProperty : string = "some value";
    public get someProperty() : string {
        return this._someProperty;
    }
    public set someProperty(v : string) {
        this._someProperty = v;
    }

    handleClickMe() {
        console.log('clicked')
        this.eventClick.emit(this.event.name)
    }

    logFoo() {
        console.log('foo log')
    }
}