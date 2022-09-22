using System.Collections.Generic;
using System.Threading.Tasks;
using FeedMe.Api.Models.Recipes;

namespace FeedMe.Api.Repositories.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        public async Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe)
        {
            var recipe = createRecipe as Recipe;
            recipe.UserId = userId;
            recipe.RecipeId = "123";
            return recipe;
        }

        public async Task DeleteRecipe(string userId, string recipeId)
        {
            
        }

        public async Task<Recipe> GetRecipe(string userId, string recipeId)
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
            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    Title = "Mac & Cheese",
                    UserId = userId
                }
            };

            return recipes;
        }

        public async Task<Recipe> UpdateRecipe(string userId, Recipe updateRecipe)
        {
            updateRecipe.UserId = userId;
            return updateRecipe;
        }
    }
}
