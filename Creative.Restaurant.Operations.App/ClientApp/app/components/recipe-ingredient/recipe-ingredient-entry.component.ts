import { Component } from '@angular/core';
import { FilterPipe } from './../../pipes';

@Component({
    selector: 'recipe-ingredient-entry',
    templateUrl: './recipe-ingredient-entry.component.html',
    styleUrls: []
})
export class RecipeIngredientEntryComponent {
    title: String;
    names: any;
    constructor() {
        this.title = "Angular 2 simple search";
        this.names = ['Prashobh', 'Abraham', 'Anil', 'Sam', 'Natasha', 'Marry', 'Zian', 'karan']
    }
}
