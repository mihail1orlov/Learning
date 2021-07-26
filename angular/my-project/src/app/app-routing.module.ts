import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TimechartsComponent} from "./components/timecharts/timecharts.component";
import {AudioComponent} from "./components/audio/audio.component";

const routes: Routes = [
  {path: 'time-charts', component: TimechartsComponent},
  {path: 'audio-content', component: AudioComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
