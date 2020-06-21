using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedMeApi.Models.Recipes
{
    public class CreateRecipe
    {
        /// <summary>
        /// Title of the recipe
        /// </summary>
        [Column("UserRecipeTitle")]
        public string Title { get; set; }

        /// <summary>
        /// Number of servings the recipe produces
        /// </summary>
        [Column("Servings")]
        public int Servings { get; set; }

        /// <summary>
        /// Time to prep the recipe
        /// </summary>
        [Column("PrepTime")]
        public string PrepTime { get; set; }

        /// <summary>
        /// Time to cook the recipe
        /// </summary>
        [Column("CookTime")]
        public string CookTime { get; set; }

        /// <summary>
        /// Description of the recipe
        /// </summary>
        [Column("UserRecipeDescription")]
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
