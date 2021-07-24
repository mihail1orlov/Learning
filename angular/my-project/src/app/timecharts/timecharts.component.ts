import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-timecharts',
  templateUrl: './timecharts.component.html',
  styleUrls: ['./timecharts.component.scss']
})
export class TimechartsComponent implements OnInit {
  public graph = {
    data: [
      { x: [1, 2, 3], y: [2, 6, 3], type: 'scatter', mode: 'lines+points', marker: {color: 'red'} },
      { x: [1, 2, 3], y: [2, 5, 3], type: 'bar' },
    ],
    layout: {width: 640, height: 480, title: 'A Fancy Plot'}
  };

  constructor() { }

  ngOnInit(): void {
  }

}
