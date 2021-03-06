import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TodoComponent } from './components/todo/todo.component';
import { RegisterComponent } from './components/account/register.component';
import { LoginComponent } from './components/account/login.component';
import { AddTodoComponent } from './components/todo/todo-form.compononent';
import { TodoService } from './components/todo/todoService';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        TodoComponent,
        RegisterComponent,
        LoginComponent,
        AddTodoComponent
    ],
    imports: [
        FormsModule,
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'todo-data', component: TodoComponent },
            { path: 'register', component: RegisterComponent },
            { path: 'login', component: LoginComponent},
            { path: '**', redirectTo: 'home' }
        ])
    ], 
    providers: [
        TodoService
    ]
})
export class AppModule {
}
