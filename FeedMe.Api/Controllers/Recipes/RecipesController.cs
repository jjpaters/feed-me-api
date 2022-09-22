﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FeedMe.Api.Exceptions;
using FeedMe.Api.Models.Recipes;
using FeedMe.Api.Repositories.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            return Created("", responseData);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteRecipe(string recipeId)
        {
            await this.recipeRepository.DeleteRecipe(this.Username, recipeId);

            return NoContent();
        }

        [HttpGet("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Recipe>> GetRecipe(string recipeId)
        {
            var responseData = await this.recipeRepository.GetRecipe(this.Username, recipeId);

            return Ok(responseData);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IList<Recipe>>> GetRecipes()
        {
            var responseData = await this.recipeRepository.GetRecipes(this.Username);

            return Ok(responseData);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Recipe>> UpdateRecipe(Recipe updateRecipe)
        {
            var responseData = await this.recipeRepository.UpdateRecipe(this.Username, updateRecipe);

            return Ok(responseData);
        }
    }
}
