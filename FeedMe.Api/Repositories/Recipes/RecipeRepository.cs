using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using FeedMe.Api.Exceptions;
using FeedMe.Api.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMe.Api.Repositories.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IDynamoDBContext dbContext;

        public RecipeRepository(IDynamoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe)
        {
            var recipe = new Recipe(createRecipe)
            {
                UserId = userId,
                RecipeId = Guid.NewGuid().ToString()
            };

            await this.dbContext.SaveAsync(recipe);

            return recipe;
        }

        public async Task DeleteRecipe(Recipe recipe)
        {
            await this.dbContext.DeleteAsync(recipe);
        }

        public async Task<Recipe> GetRecipe(string userId, string recipeId)
        {
            var scanConditions = new List<ScanCondition>
            {
                new ScanCondition("UserId", ScanOperator.Equal, userId),
                new ScanCondition("RecipeId", ScanOperator.Equal, recipeId)
            };

            var recipes = await this.dbContext.ScanAsync<Recipe>(scanConditions).GetRemainingAsync();

            return recipes?.FirstOrDefault();
        }

        public async Task<IList<Recipe>> GetRecipes(string userId, string category = null)
        {
            var scanConditions = new List<ScanCondition>
            {
                new ScanCondition("UserId", ScanOperator.Equal, userId)
            };

            if (!string.IsNullOrEmpty(category))
            {
                scanConditions.Add(new ScanCondition("Category", ScanOperator.Equal, category));
            }

            var recipes = await this.dbContext.ScanAsync<Recipe>(scanConditions).GetRemainingAsync();

            return recipes;
        }

        public async Task<Recipe> UpdateRecipe(string userId, Recipe updateRecipe)
        {
            var recipe = await this.GetRecipe(updateRecipe.UserId, updateRecipe.RecipeId);

            if (recipe == null || userId != updateRecipe.UserId)
            {
                throw new UnauthorizedRecipeAccessException();
            }

            await this.dbContext.SaveAsync(updateRecipe);

            return updateRecipe;
        }
    }
}
