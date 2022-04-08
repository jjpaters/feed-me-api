using FeedMe.Api.Exceptions;
using FeedMe.Api.Models.Recipes;
using FeedMe.Api.Repositories.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedMe.Api.Controllers.Recipes
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ProtectedControllerBase
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
            try
            {
                var responseData = await this.recipeRepository.CreateRecipe(this.UserIdentity, createRecipe);

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
        public async Task<ActionResult> DeleteRecipe(long recipeId)
        {
            try
            {
                await this.recipeRepository.DeleteRecipe(this.UserIdentity, recipeId);

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
                var responseData = await this.recipeRepository.GetRecipe(this.UserIdentity, recipeId);

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
                var responseData = await this.recipeRepository.GetRecipes(this.UserIdentity);

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
                var responseData = await this.recipeRepository.UpdateRecipe(this.UserIdentity, updateRecipe);

                return Ok(responseData);
            }
            catch (UnauthorizedRecipeAccessException)
            {
                return Unauthorized();
            }            
        }
    }
}
