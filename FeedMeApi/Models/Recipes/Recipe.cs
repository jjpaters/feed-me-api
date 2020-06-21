using System.ComponentModel.DataAnnotations.Schema;

namespace FeedMeApi.Models.Recipes
{
    /// <summary>
    /// Recipe Object
    /// </summary>
    public class Recipe : CreateRecipe
    {
        /// <summary>
        /// Identifies the recipe
        /// </summary>
        [Column("UserRecipeId")]
        public int RecipeId { get; set; }

        /// <summary>
        /// User information for the recipe
        /// </summary>
        public string UserId { get; set; }
    }
}
