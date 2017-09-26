import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'recipe-input',
    templateUrl: './recipe-input.component.html',
    styles: []
})
export class RecipeInputComponent implements OnInit {

    constructor() { }

    ngOnInit() {
    }

    onSubmit(form: any): void {
        console.log('you submitted value:', form);
    }

}
