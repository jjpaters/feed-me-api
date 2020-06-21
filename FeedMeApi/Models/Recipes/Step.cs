using System.ComponentModel.DataAnnotations.Schema;

namespace FeedMeApi.Models.Recipes
{
    /// <summary>
    /// Step Object
    /// </summary>
    public class Step
    {
        /// <summary>
        /// Identifier of the step
        /// </summary>
        [Column("UserStepId")]
        public int StepId { get; set; }

        /// <summary>
        /// Order to follow in the recipe
        /// </summary>
        [Column("UserOrderNumber")]
        public int OrderNumber { get; set; }

        /// <summary>
        /// Step text
        /// </summary>
        [Column("UserStepText")]
        public string Text { get; set; }

        /// <summary>
        /// Associated recipe
        /// </summary>
        [Column("UserRecipeId")]
        public int RecipeId { get; set; }
    }
}
