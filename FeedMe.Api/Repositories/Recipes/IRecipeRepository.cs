﻿using FeedMe.Api.Models.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedMe.Api.Repositories.Recipes
{
    public interface IRecipeRepository
    {
        /// <summary>
        /// Create a recipe for a given User.
        /// </summary>
        /// <param name="userId">Identifier of the user</param>
        /// <param name="createRecipe">Recipe to create</param>
        /// <returns>Created recipe</returns>
        Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe);

        /// <summary>
        /// Delete a recipe for a given User.
        /// </summary>
        /// <param name="recipe">Recipe to delete</param>
        /// <returns></returns>
        Task DeleteRecipe(Recipe recipe);

        /// <summary>
        /// Get a specific Recipe for a given User.
        /// </summary>
        /// <param name="userId">Identifier of the user</param>
        /// <param name="recipeId">Identifier of the recipe</param>
        /// <returns>Associated recipe</returns>
        Task<Recipe> GetRecipe(string userId, string recipeId);

        /// <summary>
        /// Get all Recipes for a given User.
        /// </summary>
        /// <param name="userId">Identifier of the user</param>
        /// <param name="category">Optional category to filter the recipes</param>
        /// <returns>Associated recipes</returns>
        Task<IList<Recipe>> GetRecipes(string userId, RecipeCategories? category = null);

        /// <summary>
        /// Update a Recipe for a given User.
        /// </summary>
        /// <param name="userId">Identifier of the user</param>
        /// <param name="updateRecipe">Recipe to update</param>
        /// <returns>Updated recipe</returns>
        Task<Recipe> UpdateRecipe(string userId, Recipe updateRecipe);
    }
}
