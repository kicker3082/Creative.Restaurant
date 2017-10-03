import { Component, OnInit, Inject, Input, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';
import { APP_CONFIG, IAppConfig } from "../../app.config";

@Component({
    selector: 'recipe',
    templateUrl: './recipe.component.html',
    styleUrls: ["./recipe.component.css"]
})
@Injectable()
export class RecipeComponent implements OnInit {
    public currentRecipe: IRecipe;
    config: IAppConfig;
    http: Http;
    sub: any;

    @Input() recipeId: number;

    constructor(http: Http, @Inject(APP_CONFIG) config: IAppConfig, private route: ActivatedRoute) {
        this.http = http;
        this.config = config;
    }

    ngOnInit(): void {

        this.sub = this.route.params.subscribe(params => {
            var id = +params['id']; // (+) converts string 'id' to a number
            this.loadRecipe(id);
        });
    }

    loadRecipe(id: number): void {
        // this.baseUrl
        this.http.get(this.config.apiEndpoint + 'recipes/' + id).subscribe(result => {

            this.currentRecipe = result.json() as IRecipe;

        },
            error => console.error(error));
    }
}
