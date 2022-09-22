using System.Collections.Generic;

namespace FeedMe.Api.Models.Recipes
{
    public class IngredientGroup
    {
        public string IngredientGroupName { get; set; }

        public IList<Ingredient> Ingredients { get; set; }
    }
}
