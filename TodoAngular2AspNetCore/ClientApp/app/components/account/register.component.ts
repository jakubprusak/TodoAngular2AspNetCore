import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { User } from '../../domain/user'
import { OperationResult } from '../../domain/common/operationResult'
import 'rxjs/Rx';

@Component({
    selector: 'register',
    template: require('./register.component.html')
})

export class RegisterComponent implements OnInit {
    private user: User;
    private http: Http;

    constructor(http: Http) {
        this.http = http;
    }

    ngOnInit(): void {
        this.user = new User();
    }

    private register(user: User): void {
        var rm = new RegiterModel(user.email, user.password, user.confirmPassword);

        //this.http.post('/api/account/register', rm)
        //    .subscribe(
        //    data => {
        //        var or = new OperationResult();
        //        or = data;
        //    } ,
        //    err => console.log(err),
        //    () => console.log('Request Complete')
        //    );


        this.http.post('/api/account/register', rm)
            .map(res => {
                return res.json().data.map((operationResult) => {
                    return new OperationResult(operationResult.success, operationResult.errors);
                });
            });
    }
}

export class RegiterModel {
    email: string;
    password: string;
    confirmPassword: string;

    constructor(email: string, password: string, confirmPassword: string) {
        this.email = email;
        this.password = password;
        this.confirmPassword = confirmPassword;
    }
}