using System;

namespace Creative.Restaurant.Operations.App.Api.Models.Status
{
    public class Status
    {
        public DateTime StatusAsOf { get; set; }
        public string SystemIs { get; set; }
        public RecipesStatus RecipesStatus { get; set; }
    }
}