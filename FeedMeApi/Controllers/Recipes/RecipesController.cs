using System.Collections.Generic;
using System.Threading.Tasks;
using FeedMeApi.Models.Recipes;
using FeedMeApi.Repositories.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace FeedMeApi.Controllers.Recipes
{
    /// <summary>
    /// Recipes Controller
    /// </summary>
    [Route("users/{userId}/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [HttpDelete("{recipeId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> DeleteRecipe(string userId, int recipeId)
        {
            await this.recipeRepository.DeleteRecipe(userId, recipeId);

            return NoContent();
        }

        [HttpGet("{recipeId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Recipe>> GetRecipe(string userId, int recipeId)
        {
            var recipe = await this.recipeRepository.GetRecipe(userId, recipeId);

            if (recipe == null)
            {
                return NotFound($"Unable to find the recipe.");
            }

            return Ok(recipe);
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IList<Recipe>>> GetRecipe(string userId)
        {
            var recipes = await this.recipeRepository.GetRecipes(userId);

            return Ok(recipes);
        }

        [HttpPost()]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Recipe>> PostRecipe(string userId, [FromBody] CreateRecipe createRecipe)
        {
            var recipe = await this.recipeRepository.CreateRecipe(userId, createRecipe);

            return Ok(recipe);
        }

        [HttpPatch("{recipeId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Recipe>> PatchRecipe(string userId, [FromBody] Recipe updateRecipe)
        {
            var recipe = await this.recipeRepository.UpdateRecipe(userId, updateRecipe);

            if (recipe == null)
            {
                return NotFound($"Unable to find a recipe.");
            }

            return Ok(recipe);
        }
      
    }
}