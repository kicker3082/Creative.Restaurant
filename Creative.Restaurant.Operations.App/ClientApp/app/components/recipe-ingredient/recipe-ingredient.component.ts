import { Component, Inject, Input, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'recipe-ingredient',
    templateUrl: './recipe-ingredient.component.html'
})
export class RecipeIngredientComponent implements OnInit {
    @Input()
    public id: number;

    public recipeIngredient: IRecipeIngredient;
    http: Http;
    baseUrl: string;
    sub: any;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit(): void {
            this.getRecipeIngredient();
    }

    getRecipeIngredient(): void {
        this.http.get('http://localhost:45043/' + 'api/recipeingredients/' + this.id).subscribe(result => {

            this.recipeIngredient = result.json() as IRecipeIngredient;

        }, error => console.error(error));
    }
}

