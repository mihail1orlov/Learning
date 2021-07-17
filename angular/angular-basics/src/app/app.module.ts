import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {PostComponent} from './post/post.component';
import {Post4Component} from './post4/post4.component';
import {FormsModule} from "@angular/forms";
import { TestRefreshComponent } from './test-refresh/test-refresh.component';

@NgModule({
  declarations: [
    AppComponent,
    PostComponent,
    Post4Component,
    TestRefreshComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
