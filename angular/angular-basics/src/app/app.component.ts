import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Dynamic title';
  number = 42;
  arr = [1, 2, 3];
  user = { name: 'Igor', age: 34, doc: {id: 234}};
  images = ['https://freepngimg.com/thumb/wolf_tattoos/3-2-wolf-tattoos-picture-thumb.png', 'https://freepngimg.com/thumb/wolf_tattoos/8-2-wolf-tattoos-png-clipart-thumb.png'];
  index = 0;
  img = this.images[this.index];
  img1 = this.images[this.arr.length - 1];

  constructor() {
    const callback = () => {
      this.img1 = this.images[this.index];
      this.index = ++this.index % this.images.length;
      this.img = this.images[this.index];
      console.log('timeout is over');
      setTimeout(callback, 1000);
    };

    callback();
  }
}
