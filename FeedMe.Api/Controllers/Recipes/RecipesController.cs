using FeedMe.Api.Models.Recipes;
using FeedMe.Api.Repositories.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedMe.Api.Controllers.Recipes
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class RecipesController : AuthorizedControllerBase
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }
                
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Recipe>> CreateRecipe(CreateRecipe createRecipe)
        {
            var responseData = await this.recipeRepository.CreateRecipe(this.Username, createRecipe);

            return Created($"/recipes/{responseData.RecipeId}", responseData);
        }

        [HttpDelete("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteRecipe(string recipeId)
        {
            var recipe = await this.recipeRepository.GetRecipe(this.Username, recipeId);

            await this.recipeRepository.DeleteRecipe(recipe);

            return NoContent();
        }

        [HttpGet("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Recipe>> GetRecipe(string recipeId)
        {
            var responseData = await this.recipeRepository.GetRecipe(this.Username, recipeId);

            if (responseData == null)
            {
                return NotFound();
            }

            return Ok(responseData);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IList<Recipe>>> GetRecipes(RecipeCategories? category = null)
        {
            var responseData = await this.recipeRepository.GetRecipes(this.Username, category);

            return Ok(responseData);
        }

        [HttpPut("{recipeId}")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Recipe>> UpdateRecipe(string recipeId, Recipe updateRecipe)
        {
            if (!string.Equals(recipeId, updateRecipe.RecipeId))
            {
                return BadRequest("Recipe ID does not match the Recipe object.");
            }

            var responseData = await this.recipeRepository.UpdateRecipe(this.Username, updateRecipe);

            return Ok(responseData);
        }
    }
}
