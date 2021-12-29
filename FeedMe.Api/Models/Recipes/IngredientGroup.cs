using System.Collections.Generic;

namespace FeedMe.Api.Models.Recipes
{
    public class IngredientGroup
    {
        public long IngredientGroupId { get; set; }

        public string IngredientGroupName { get; set; }

        public IList<Ingredient> Ingredients { get; set; }
    }
}
