using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedMeApi.Models.Recipes;

namespace FeedMeApi.Repositories.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IList<Recipe> recipes;

        public RecipeRepository()
        {
            this.recipes = new List<Recipe>();
            this.GenerateMockData();
        }

        public async Task<Recipe> CreateRecipe(string userId, CreateRecipe createRecipe)
        {
            var recipe = new Recipe
            {
                CookTime = createRecipe.CookTime,
                Description = createRecipe.Description,
                Ingredients = createRecipe.Ingredients,
                PrepTime = createRecipe.PrepTime,
                RecipeId = Guid.NewGuid().ToString(),
                Servings = createRecipe.Servings,
                Steps = createRecipe.Steps,
                Title = createRecipe.Title,
                User = new Models.Auth.User
                {
                    UserId = userId
                }
            };

            this.recipes.Add(recipe);

            return recipe;
        }

        public async Task DeleteRecipe(string userId, string recipeId)
        {
            var recipe = this.recipes.FirstOrDefault(x => x.User.UserId == userId && x.RecipeId == recipeId);

            if (recipe != null)
            {
                this.recipes.Remove(recipe);
            }
        }

        public async Task<Recipe> GetRecipe(string userId, string recipeId)
        {
            var recipe = this.recipes.FirstOrDefault(x => x.User.UserId == userId && x.RecipeId == recipeId);

            return recipe;
        }

        public async Task<IList<Recipe>> GetRecipes(string userId)
        {
            var recipes = this.recipes.Where(x => x.User.UserId == userId).ToList();

            return recipes;
        }

        public async Task<Recipe> UpdateRecipe(string userId, Recipe updateRecipe)
        {
            var recipe = this.recipes.FirstOrDefault(x => x.User.UserId == userId && x.RecipeId == updateRecipe.RecipeId);

            if (recipe != null)
            {
                recipe.CookTime = updateRecipe.CookTime;
                recipe.Description = updateRecipe.Description;
                recipe.Ingredients = updateRecipe.Ingredients;
                recipe.PrepTime = updateRecipe.PrepTime;
                recipe.Servings = updateRecipe.Servings;
                recipe.Steps = updateRecipe.Steps;
                recipe.Title = updateRecipe.Title;
            }

            return recipe;
        }

        private void GenerateMockData()
        {
            this.recipes.Add(new Recipe
            {
                User = new Models.Auth.User
                {
                    UserId = "100"
                },
                RecipeId = Guid.NewGuid().ToString(),
                Title = "Recipe 1",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu bibendum lacus. Proin pharetra nibh a velit varius bibendum. Praesent nec consequat orci. Nunc feugiat orci felis, quis varius mauris mollis luctus. Cras elementum lorem id suscipit consequat. Cras malesuada, leo eget pretium euismod, nibh lectus sollicitudin neque, id vehicula est ex quis quam. Aliquam ac maximus nulla.",
                Servings = 1,
                CookTime = "10m",
                PrepTime = "0m",
                Ingredients = new List<Ingredient>(),
                Steps = new List<Step>()
            });

            this.recipes.Add(new Recipe
            {
                User = new Models.Auth.User
                {
                    UserId = "100"
                },
                RecipeId = Guid.NewGuid().ToString(),
                Title = "Recipe 2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu bibendum lacus. Proin pharetra nibh a velit varius bibendum. Praesent nec consequat orci. Nunc feugiat orci felis, quis varius mauris mollis luctus. Cras elementum lorem id suscipit consequat. Cras malesuada, leo eget pretium euismod, nibh lectus sollicitudin neque, id vehicula est ex quis quam. Aliquam ac maximus nulla.",
                Servings = 1,
                CookTime = "10m",
                PrepTime = "0m",
                Ingredients = new List<Ingredient>(),
                Steps = new List<Step>()
            });

            this.recipes.Add(new Recipe
            {
                User = new Models.Auth.User
                {
                    UserId = "100"
                },
                RecipeId = Guid.NewGuid().ToString(),
                Title = "Recipe 3",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu bibendum lacus. Proin pharetra nibh a velit varius bibendum. Praesent nec consequat orci. Nunc feugiat orci felis, quis varius mauris mollis luctus. Cras elementum lorem id suscipit consequat. Cras malesuada, leo eget pretium euismod, nibh lectus sollicitudin neque, id vehicula est ex quis quam. Aliquam ac maximus nulla.",
                Servings = 1,
                CookTime = "10m",
                PrepTime = "0m",
                Ingredients = new List<Ingredient>(),
                Steps = new List<Step>()
            });

            this.recipes.Add(new Recipe
            {
                User = new Models.Auth.User
                {
                    UserId = "100"
                },
                RecipeId = Guid.NewGuid().ToString(),
                Title = "Recipe 4",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu bibendum lacus. Proin pharetra nibh a velit varius bibendum. Praesent nec consequat orci. Nunc feugiat orci felis, quis varius mauris mollis luctus. Cras elementum lorem id suscipit consequat. Cras malesuada, leo eget pretium euismod, nibh lectus sollicitudin neque, id vehicula est ex quis quam. Aliquam ac maximus nulla.",
                Servings = 1,
                CookTime = "10m",
                PrepTime = "0m",
                Ingredients = new List<Ingredient>(),
                Steps = new List<Step>()
            });

            this.recipes.Add(new Recipe
            {
                User = new Models.Auth.User
                {
                    UserId = "100"
                },
                RecipeId = Guid.NewGuid().ToString(),
                Title = "Recipe 5",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu bibendum lacus. Proin pharetra nibh a velit varius bibendum. Praesent nec consequat orci. Nunc feugiat orci felis, quis varius mauris mollis luctus. Cras elementum lorem id suscipit consequat. Cras malesuada, leo eget pretium euismod, nibh lectus sollicitudin neque, id vehicula est ex quis quam. Aliquam ac maximus nulla.",
                Servings = 1,
                CookTime = "10m",
                PrepTime = "0m",
                Ingredients = new List<Ingredient>(),
                Steps = new List<Step>()
            });
        }
    }
}
