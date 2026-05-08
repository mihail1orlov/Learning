// This module is the entry point of the application.

// Libraries are installed with npm and pulled in via `import`.
import { NgModule }      from '@angular/core';            // The NgModule decorator — used to declare a module.
// Every official Angular library is published under the @angular scope.
import { BrowserModule } from '@angular/platform-browser'; // Browser bootstrap support.
import { FormsModule }   from '@angular/forms';            // Template-driven forms (needed for [(ngModel)]).
import { AppComponent }  from './app.component';          // The root component.

// NgModule is a class decorator. It accepts a configuration object
// whose properties describe the module's metadata.
@NgModule({
    exports: [],                       // View classes re-exported for use by other modules.
    imports:      [ BrowserModule, FormsModule ],
    declarations: [ AppComponent ],    // View classes that belong to this module.
                                       // Angular has three kinds of view classes:
                                       //   - components
                                       //   - directives
                                       //   - pipes
    providers: [],                     // Service classes provided by the module.
    bootstrap: [ AppComponent ]        // The component used as the application's root on load.
})

// Root module.
export class AppModule { }
