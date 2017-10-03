interface IRecipe {
    id: number;
    name: string;
    description: string;
    recipeIngredientIds: number[];
    makesQuantity: number;
    makesUnitAbbr: string;

}
