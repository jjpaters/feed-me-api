using FeedMeApi.Models.Auth;

namespace FeedMeApi.Models.Recipes
{
    /// <summary>
    /// Recipe Object
    /// </summary>
    public class Recipe : CreateRecipe
    {
        /// <summary>
        /// User information for the recipe
        /// </summary>
        public User User { get; set; }
    }
}
