import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TimechartsComponent } from "./timecharts/timecharts.component";

const routes: Routes = [
  { path: 'time-charts', component: TimechartsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
