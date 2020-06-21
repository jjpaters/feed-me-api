using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedMeApi.Models.Recipes;
using FeedMeApi.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace FeedMeApi.Repositories.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly FeedMeContext database;

        public RecipeRepository(FeedMeContext database)
        {
            this.database = database;
        }

        public async Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe)
        {
            var recipe = new Recipe
            {
                CookTime = createRecipe.CookTime,
                Description = createRecipe.Description,
                PrepTime = createRecipe.PrepTime,
                Servings = createRecipe.Servings,
                Title = createRecipe.Title,
                UserId = userId
            };

            await this.database.UserRecipes.AddAsync(recipe);

            await this.database.SaveChangesAsync();

            if (createRecipe.Ingredients != null)
            {
                foreach(var ingredient in createRecipe.Ingredients)
                {
                    ingredient.RecipeId = recipe.RecipeId;
                    await this.database.UserIngredients.AddAsync(ingredient);
                }
            }

            if (createRecipe.Steps != null)
            {
                foreach (var step in createRecipe.Steps)
                {
                    step.RecipeId = recipe.RecipeId;
                    await this.database.UserSteps.AddAsync(step);
                }
            }

            await this.database.SaveChangesAsync();

            return recipe;
        }

        public async Task DeleteRecipe(string userId, int recipeId)
        {
            var recipe = await this.GetRecipe(userId, recipeId);

            if (recipe != null)
            {
                this.database.UserRecipes.Remove(recipe);

                await this.database.SaveChangesAsync();

            }
        }

        public async Task<Recipe> GetRecipe(string userId, int recipeId)
        {
            var recipe = await this.database.UserRecipes
                .Include(x => x.Ingredients)
                .Include(x => x.Steps)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.RecipeId == recipeId);

            return recipe;
        }

        public async Task<IList<Recipe>> GetRecipes(string userId)
        {
            var recipes = await this.database.UserRecipes
                .Include(x => x.Ingredients)
                .Include(x => x.Steps)
                .Where(x => x.UserId == userId).ToListAsync();

            return recipes;
        }

        public async Task<Recipe> UpdateRecipe(string userId, Recipe updateRecipe)
        {
            var recipe = await this.GetRecipe(userId, updateRecipe.RecipeId);

            if (recipe != null)
            {
                recipe.CookTime = updateRecipe.CookTime;
                recipe.Description = updateRecipe.Description;
                recipe.Ingredients = updateRecipe.Ingredients;
                recipe.PrepTime = updateRecipe.PrepTime;
                recipe.Servings = updateRecipe.Servings;
                recipe.Steps = updateRecipe.Steps;
                recipe.Title = updateRecipe.Title;

                this.database.Update(recipe);

                await this.database.SaveChangesAsync();
            }

            return recipe;
        }

    }
}
