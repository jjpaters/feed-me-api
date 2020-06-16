using System.Collections.Generic;

namespace FeedMeApi.Models.Recipes
{
    /// <summary>
    /// Crete Recipe Object
    /// </summary>
    public class CreateRecipe
    {
        /// <summary>
        /// Identifies the recipe
        /// </summary>
        public string RecipeId { get; set; }

        /// <summary>
        /// Title of the recipe
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Number of servings the recipe produces
        /// </summary>
        public int Servings { get; set; }

        /// <summary>
        /// Time to prep the recipe
        /// </summary>
        public string PrepTime { get; set; }

        /// <summary>
        /// Time to cook the recipe
        /// </summary>
        public string CookTime { get; set; }

        /// <summary>
        /// Description of the recipe
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// List of Steps
        /// </summary>
        public IList<Step> Steps { get; set; }

        /// <summary>
        /// List of Ingredients
        /// </summary>
        public IList<Ingredient> Ingredients { get; set; }
    }
}
