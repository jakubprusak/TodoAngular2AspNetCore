import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Todo } from '../../domain/todo';
import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class TodoService {
    private todoUrl = '/api/todo'; 

    constructor(private http: Http) {
    }

    public addTask(todo: Todo) {
        let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
        let options = new RequestOptions({ headers: headers }); // Create a request option

        return this.http.post(this.todoUrl, todo, options);
    }

    public getTasks(): Observable<Todo[]> {
        return this.http.get(this.todoUrl)  
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

    public deleteTask(id :number) {
        return this.http.delete(this.todoUrl + "/" + id.toString());
    }
}
