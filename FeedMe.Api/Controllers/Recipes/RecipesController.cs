using FeedMe.Api.Exceptions;
using FeedMe.Api.Models.Recipes;
using FeedMe.Api.Repositories.Recipes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedMe.Api.Controllers.Recipes
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Recipe>> CreateRecipe(string userId, CreateRecipe createRecipe)
        {
            try
            {
                var responseData = await this.recipeRepository.CreateRecipe(userId, createRecipe);

                return Created("", responseData);
            }
            catch (UnauthorizedRecipeAccessException)
            {
                return Unauthorized();
            }            
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteRecipe(string userId, long recipeId)
        {
            try
            {
                await this.recipeRepository.DeleteRecipe(userId, recipeId);

                return NoContent();
            }
            catch (UnauthorizedRecipeAccessException)
            {
                return Unauthorized();
            }            
        }

        [HttpGet("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Recipe>> GetRecipe(long recipeId)
        {
            try
            {
                var userId = ""; // TODO: resolve User ID

                var responseData = await this.recipeRepository.GetRecipe(userId, recipeId);

                return Ok(responseData);
            }
            catch (UnauthorizedRecipeAccessException)
            {
                return Unauthorized();
            }            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IList<Recipe>>> GetRecipes()
        {
            try
            {
                var userId = ""; // TODO: resolve User ID

                var responseData = await this.recipeRepository.GetRecipes(userId);

                return Ok(responseData);
            }
            catch (UnauthorizedRecipeAccessException)
            {
                return Unauthorized();
            }            
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Recipe>> UpdateRecipe(Recipe updateRecipe)
        {
            try
            {
                var userId = ""; // TODO: resolve User ID

                var responseData = await this.recipeRepository.UpdateRecipe(userId, updateRecipe);

                return Ok(responseData);
            }
            catch (UnauthorizedRecipeAccessException)
            {
                return Unauthorized();
            }            
        }
    }
}
