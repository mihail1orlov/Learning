// Этот модуль будет входной точкой в приложение

// Библиотеки устанавливаются через пакетный менеджер npm и импортируются с помощью директивы import
import { NgModule }      from '@angular/core'; // декоратора NgModule, нужен для создания модуля
// Имя каждой библиотеки Angular начинается с префикса @angular
import { BrowserModule } from '@angular/platform-browser'; // необходимый для работы с браузером
import { FormsModule }   from '@angular/forms'; // необходимый для работы с формами html и, в частности, с элементами input
import { AppComponent }   from './app.component'; // функциональность корневого компонента приложения

// NgModule представляет функцию-декоратора,
@NgModule({// которая принимает объект, свойства которого описывают метаданные модуля
    exports: [], // набор классов представлений, которые должны использоваться в шаблонах компонентов из других модулей
    imports:      [ BrowserModule, FormsModule ],
    declarations: [ AppComponent ], // классы представлений (view classes), которые принадлежат модулю
        // Angular имеет три типа классов представлений
            // - components
            // - directives
            // - pipes (каналы)
    providers: [], // классы, создающие сервисы, используемые модулем
    bootstrap:    [ AppComponent ]
})

// root module
export class AppModule { }