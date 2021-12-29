using FeedMe.Api.Models.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedMe.Api.Repositories.Recipes
{
    public interface IRecipeRepository
    {
        Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe);

        Task DeleteRecipe(string userId, long recipeId);

        Task<Recipe> GetRecipe(string userId, long recipeId);

        Task<IList<Recipe>> GetRecipes(string userId);

        Task<Recipe> UpdateRecipe(string userId, Recipe updateRecipe);
    }
}
