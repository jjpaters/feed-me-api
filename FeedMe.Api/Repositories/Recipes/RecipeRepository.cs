using FeedMe.Api.Models.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedMe.Api.Repositories.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        public Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRecipe(string userId, long recipeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Recipe> GetRecipe(string userId, long recipeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Recipe>> GetRecipes(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Recipe> UpdateRecipe(string userId, Recipe updateRecipe)
        {
            throw new System.NotImplementedException();
        }
    }
}
