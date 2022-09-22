using System.Collections.Generic;

namespace FeedMe.Api.Models.Recipes
{
    public class Recipe : CreateRecipe
    {
        public string UserId { get; set; }

        public string RecipeId { get; set; }
    }
}
