import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { User } from '../../domain/user'

@Component({
    selector: 'login',
    template: require('./login.component.html')
})

export class LoginComponent implements OnInit {

    private user: User;

    ngOnInit(): void {
        this.user = new User();
    }

    constructor(http: Http) {

    }

    public chhangeUserName(user: User): void {

    }
}
