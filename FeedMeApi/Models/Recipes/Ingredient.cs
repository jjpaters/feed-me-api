using System.ComponentModel.DataAnnotations.Schema;

namespace FeedMeApi.Models.Recipes
{
    /// <summary>
    /// Ingredient Object
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Identifier of the ingredient
        /// </summary>
        [Column("UserIngredientId")]
        public int IngredientId { get; set; }

        /// <summary>
        /// Ingredient text
        /// </summary>
        [Column("UserIngredientText")]
        public string Text { get; set; }

        /// <summary>
        /// Associated recipe
        /// </summary>
        [Column("UserRecipeId")]
        public int RecipeId { get; set; }
    }
}
