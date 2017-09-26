using System.Collections.Generic;
using System.Linq;
using Creative.Restaurant.Operations.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Creative.Restaurant.Operations.Data.Context
{
    public static class DbContextExtension
    {
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this OperationsContext context)
        {
            if (!context.Units.Any())
            {
                var newUnits = new List<Unit>
                {
                    new Unit
                    { Abbr = "fl oz",
                        Name = "fluid ounce",
                        IsByWeight = false,
                        IsByVolume = true
                    },
                    new Unit
                    {
                        Abbr = "qt",
                        Name = "quart",
                        IsByWeight = false,
                        IsByVolume = true
                    },
                    new Unit
                    {
                        Abbr = "each",
                        Name = "each",
                        IsByVolume = false,
                        IsByWeight = false
                    },
                    new Unit()
                    {
                        Abbr = "oz",
                        Name = "ounce",
                        IsByVolume = false,
                        IsByWeight = true
                    },
                    new Unit
                    {
                        Abbr = "lb",
                        Name = "pound",
                        IsByVolume = false,
                        IsByWeight = true
                    }
                };

                //var units = JsonConvert.DeserializeObject<List<Unit>>(
                //File.ReadAllText(@"Seed" + Path.DirectorySeparatorChar + "units.json"));
                context.Units.AddRange(newUnits);
                context.SaveChanges();

            }

            IDictionary<string, Unit> units = context.Units.ToDictionary(u => u.Abbr, u => u);

            if (!context.Ingredients.Any())
            {
                var newIngredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Name = "Water",
                        Unit = units["fl oz"]
                    },
                    new Ingredient
                    {
                        Name = "Chicken, Whole Roaster",
                        Unit = units["each"]
                    },
                    new Ingredient
                    {
                        Name = "Onion, Yellow Medium",
                        Unit = units["each"]
                    },
                    new Ingredient
                    {
                        Name = "Carrot, Whole Fresh",
                        Unit = units["oz"]
                    },
                    new Ingredient
                    {
                        Name = "Celery, Fresh",
                        Unit = units["oz"]
                    }
                };

                //List<Ingredient> ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(
                //    File.ReadAllText(@"Seed" + Path.DirectorySeparatorChar + "ingredients.json"));
                context.Ingredients.AddRange(newIngredients);
                context.SaveChanges();
            }

            IDictionary<string, Ingredient> ingredients = context.Ingredients.ToDictionary(u => u.Name, u => u);

            //if (!context.RecipeIngredients.Any())
            //{
            //    var recipeIngredients = new List<RecipeIngredient>
            //    {
            //        new RecipeIngredient
            //        {
            //            Ingredient = ingredients["Water"],
            //            Unit = units["fl oz"],
            //            Quantity = 128
            //        },
            //        new RecipeIngredient
            //        {
            //            Ingredient = ingredients["Chicken, Whole Roaster"],
            //            Unit = units["lb"],
            //            Quantity = 4
            //        }
            //    };

            //    //var recipeIngredients = JsonConvert.DeserializeObject<List<RecipeIngredient>>(
            //    //File.ReadAllText(@"Seed" + Path.DirectorySeparatorChar + "recipe-ingredients.json"));
            //    context.RecipeIngredients.AddRange(recipeIngredients);
            //    context.SaveChanges();
            //}

            if (!context.Recipes.Any())
            {
                var recipes = new List<Recipe>
                {
                    new Recipe
                    {
                        Name = "Chicken Stock",
                        Description = "A rich and flavorful base for use in soups, sauces, and gravies.",
                        MakesQuantity = 2,
                        MakesUnit = units["qt"],
                        Ingredients = new List<RecipeIngredient>
                        {
                            new RecipeIngredient
                            {
                                Ingredient = ingredients["Water"],
                                Unit = units["fl oz"],
                                Quantity = 128
                            },
                            new RecipeIngredient
                            {
                                Ingredient = ingredients["Chicken, Whole Roaster"],
                                Unit = units["each"],
                                Quantity = 1
                            },
                            new RecipeIngredient
                            {
                                Ingredient = ingredients["Onion, Yellow Medium"],
                                Unit = units["oz"],
                                Quantity = 12
                            },
                            new RecipeIngredient
                            {
                                Ingredient = ingredients["Carrot, Whole Fresh"],
                                Unit = units["oz"],
                                Quantity = 8
                            },
                            new RecipeIngredient
                            {
                                Ingredient = ingredients["Celery, Fresh"],
                                Unit = units["oz"],
                                Quantity = 10
                            }

                        }
                    }
                };
                context.Recipes.AddRange(recipes);
                context.SaveChanges();
            }
        }
    }
}