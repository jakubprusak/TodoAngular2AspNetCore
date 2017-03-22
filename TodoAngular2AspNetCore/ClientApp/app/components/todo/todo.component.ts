import { Component, OnInit, Input } from '@angular/core';
import { Http } from '@angular/http';
import { Todo } from '../../domain/todo';
import { TodoService } from './todoService'

@Component({
    selector: 'todos-data',
    template: require('./todo.component.html')
})
export class TodoComponent implements OnInit {
    private todos: Todo[];

    constructor(private todoService: TodoService) {
    }

    ngOnInit() {
        // Load comments
        this.loadTodos();
    }


    private loadTodos() {
        this.todoService.getTasks().subscribe(
            response => {
                // Emit list event
                this.todos = response;
            },
            err => {
                // Log errors if any
                console.log(err);
            });
    }

    public addEvent(todo:Todo) {
        this.loadTodos();
    }

    private changeStatusTask(todo: Todo) : void {
        
    }

    private deleteTodo(todo: Todo): void {
        this.todoService.deleteTask(todo.todoId).subscribe(response => {
            this.loadTodos();
        });
    }
}
