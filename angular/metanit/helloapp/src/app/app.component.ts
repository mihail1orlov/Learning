import { Component } from '@angular/core';

// To declare a component we import the @Component decorator from
// @angular/core. The decorator marks a class as an Angular component.
@Component(
    // Configuration object — tells Angular how to build and render
    // the component. The @Component decorator attaches this metadata
    // to the AppComponent class below.
    {
        selector: 'my-app',         // CSS selector for the host HTML element

        // Template = the component's view; it describes how the
        // component is rendered.
        template: `<label>Enter your name:</label>
                 <input [(ngModel)]="name" placeholder="name">
                 <h1>Welcome, {{name}}!</h1>`
    }
)

// `export` so other modules can import this class.
export class AppComponent {
    name = '';
}
