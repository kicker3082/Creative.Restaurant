import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { RecipeComponent } from './components/recipe/recipe.component';
import { RecipeIngredientComponent } from './components/recipe-ingredient/recipe-ingredient.component';
import { RecipeEntryComponent } from './components/recipe/recipe-entry.component';
import { RecipeIngredientEntryComponent } from './components/recipe-ingredient/recipe-ingredient-entry.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        RecipeComponent,
        RecipeIngredientComponent,
        RecipeEntryComponent,
        RecipeIngredientEntryComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'recipe/:id', component: RecipeComponent },
            { path: 'recipe-ingredient/:id', component: RecipeIngredientComponent },
            { path: 'recipe-entry', component: RecipeEntryComponent },
            { path: 'recipe-ingredient-entry', component: RecipeIngredientEntryComponent },

            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
