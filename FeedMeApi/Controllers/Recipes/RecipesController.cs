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

        [HttpGet("{recipeId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Recipe>> GetRecipe(string userId, string recipeId)
        {
            var recipe = await this.recipeRepository.GetRecipe(userId, recipeId);

            if (recipe == null)
            {
                return NotFound($"Unable to find a recipe.");
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
    }
}
