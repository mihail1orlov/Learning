import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-refresh',
  templateUrl: './test-refresh.component.html',
  styleUrls: ['./test-refresh.component.scss']
})
export class TestRefreshComponent implements OnInit {
  refreshText = 0;

  constructor() { }

  ngOnInit(): void {
    const callback = () => {
      this.refreshText++;
      setTimeout(callback, 1000);
    };

    callback();
  }
}
