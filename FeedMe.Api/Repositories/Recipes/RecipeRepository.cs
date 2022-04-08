using FeedMe.Api.Exceptions;
using FeedMe.Api.Models.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedMe.Api.Repositories.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        public async Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe)
        {
            var recipe = new Recipe
            {
                UserId = userId
            };

            return recipe;
        }

        public async Task DeleteRecipe(string userId, long recipeId)
        {
            throw new UnauthorizedRecipeAccessException();
        }

        public async Task<Recipe> GetRecipe(string userId, long recipeId)
        {
            var recipe = new Recipe
            {
                UserId = userId,
                RecipeId = recipeId
            };

            return recipe;
        }

        public async Task<IList<Recipe>> GetRecipes(string userId)
        {
            throw new UnauthorizedRecipeAccessException();
        }

        public async Task<Recipe> UpdateRecipe(string userId, Recipe updateRecipe)
        {
            throw new UnauthorizedRecipeAccessException();
        }
    }
}
