import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Http } from '@angular/http';
import { Todo } from '../../domain/todo';
import { TodoService } from './todoService';

@Component({
    selector: 'todo-form',
    template: require('./todo-form.compononent.html')
})
export class AddTodoComponent implements OnInit {
    @Output() notifyTodos: EventEmitter<any> = new EventEmitter();
    private todo: Todo;

    constructor(private todoService: TodoService) {
        
    }

    ngOnInit(): void {
        this.todo = new Todo();
    }

    private addTask(todo: Todo): void {
        this.todoService.addTask(todo).subscribe(response => {
            this.notifyTodos.emit(todo);
            this.todo = new Todo();
        });
        
    }
}
