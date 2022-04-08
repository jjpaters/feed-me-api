using System.Collections.Generic;

namespace FeedMe.Api.Models.Recipes
{
    public class CreateRecipe
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public RecipeClassifications Classification { get; set; }

        public long Servings { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }        

        public IList<Step> Steps { get; set; }

        public IList<IngredientGroup> IngredientGroups { get; set; }
    }
}
