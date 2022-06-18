import { Component } from '@angular/core';
     
@Component({ // функция декоратор, ассоциирует метаданные с классом компонента AppComponent
    selector: 'my-app', // селектор css для HTML-элемента
    
    // шаблон, который указывает, как надо визуализировать компонент
    template: `<label>Введите имя:</label>
                 <input [(ngModel)]="name" placeholder="name">
                 <h1>Добро пожаловать {{name}}!</h1>`
})
export class AppComponent {
    name= '';
}