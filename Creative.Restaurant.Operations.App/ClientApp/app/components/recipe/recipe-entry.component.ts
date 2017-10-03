import { Component, Inject, Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { APP_CONFIG, IAppConfig } from "../../app.config";


@Component({
    selector: 'recipe-entry',
    templateUrl: './recipe-entry.component.html',
    styleUrls: ["./recipe-entry.component.css"]
})
@Injectable()
export class RecipeEntryComponent {
    public currentRecipe: IRecipe;
    public id: number;

    public nameInput: string;
    public descriptionInput: string;
    public qtyInput: number;
    public unitInput: string;

    http: Http;
    baseUrl: string;
    config: IAppConfig;
    sub: any;
    router: Router;

    constructor(
            http: Http,
            @Inject('BASE_URL') baseUrl: string,
            @Inject(APP_CONFIG) config: IAppConfig,
            private route: ActivatedRoute,
            router: Router) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.router = router;
        this.config = config;
        this.currentRecipe = {
            id: 0,
            name: "",
            description: "",
            makesQuantity: 0,
            makesUnitAbbr: "",
            recipeIngredientIds: []
        };
    }

    setRecipeName(name: string): void {
        this.currentRecipe.name = name;
    }

    setRecipeDescription(description: string): void {
        this.currentRecipe.description = description;
    }

    setRecipeQuantity(quantity: number): void {
        this.currentRecipe.makesQuantity = quantity;
    }

    setRecipeUnits(unit: string): void {
        this.currentRecipe.makesUnitAbbr = unit;
    }

    addRecipeIngredient(id: number): void {
        this.currentRecipe.recipeIngredientIds.push(id);
    }

    removeRecipeIngredient(id: number): void {
        var index = this.currentRecipe.recipeIngredientIds.indexOf(id, 0);
        if (index > -1) {
            this.currentRecipe.recipeIngredientIds.splice(index, 1);
        }
    }

    postRecipe(): void {
        var headers = new Headers({ 'Content-Type': 'application/json' });

        var objToSend = JSON.stringify(this.currentRecipe);

        this.http.post(this.config.apiEndpoint + 'recipes', objToSend, { headers: headers }).subscribe(result => {

            this.currentRecipe = result.json() as IRecipe;
            var addr = this.baseUrl + 'recipe/' + this.currentRecipe.id;
            this.router.navigate([addr]);
        },
            error => console.error(error));
    }
}