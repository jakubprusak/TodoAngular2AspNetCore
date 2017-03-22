import { Component } from '@angular/core';

@Component({
    selector: 'counter',
    template: require('./counter.component.html')
})
export class CounterComponent {
    private currentCount : number = 0;

    public incrementCounter() {
        this.currentCount++;
    }
}
