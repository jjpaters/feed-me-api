using System.Collections.Generic;
using System.Threading.Tasks;
using FeedMe.Api.Models.Recipes;

namespace FeedMe.Api.Repositories.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        public async Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe)
        {
<<<<<<< HEAD
            var recipe = createRecipe as Recipe;
            recipe.UserId = userId;
            recipe.RecipeId = "123";
=======
            var recipe = new Recipe
            {
                UserId = userId
            };

>>>>>>> 187ac24890dc4eef43f04f37cf4f4ad2e9fb68e4
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
<<<<<<< HEAD
                    Title = "Mac & Cheese",
                    UserId = userId
=======
                    UserId = userId,
>>>>>>> 187ac24890dc4eef43f04f37cf4f4ad2e9fb68e4
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
