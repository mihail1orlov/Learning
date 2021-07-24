import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TimechartsComponent } from './timecharts/timecharts.component';

import { PlotlyModule } from 'angular-plotly.js';
import * as PlotlyJS from 'plotly.js-dist';
PlotlyModule.plotlyjs = PlotlyJS;

@NgModule({
  declarations: [
    AppComponent,
    TimechartsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PlotlyModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
