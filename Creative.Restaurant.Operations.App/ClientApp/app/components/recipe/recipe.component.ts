import { Component, OnInit, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'recipe',
    templateUrl: './recipe.component.html',
    styleUrls: ["./recipe.component.css"]
})
export class RecipeComponent implements OnInit {
    public currentRecipe: IRecipe;
    public id: number;
    http: Http;
    baseUrl: string;
    sub: any;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit(): void {

        this.sub = this.route.params.subscribe(params => {
            this.id = +params['id']; // (+) converts string 'id' to a number
            this.loadRecipe();
        });

    }

    loadRecipe(): void {
        // this.baseUrl
        this.http.get('http://localhost:45043/' + 'api/recipes/' + this.id).subscribe(result => {

            this.currentRecipe = result.json() as IRecipe;

        }, error => console.error(error));
    }

}
