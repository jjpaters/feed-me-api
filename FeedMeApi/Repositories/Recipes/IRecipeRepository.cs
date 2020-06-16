using System.Collections.Generic;
using System.Threading.Tasks;
using FeedMeApi.Models.Recipes;

namespace FeedMeApi.Repositories.Recipes
{
    public interface IRecipeRepository
    {
        Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe);

        Task DeleteRecipe(string userId, string recipeId);

        Task<Recipe> GetRecipe(string userId, string recipeId);

        Task<IList<Recipe>> GetRecipes(string userId);

        Task<Recipe> UpdateRecipe(string userId, Recipe updateRecipe);
    }
}
