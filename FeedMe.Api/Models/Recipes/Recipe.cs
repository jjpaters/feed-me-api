using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;

namespace FeedMe.Api.Models.Recipes
{
    [DynamoDBTable("Recipes")]
    public class Recipe : CreateRecipe
    {
        [DynamoDBHashKey]
        public string UserId { get; set; }


        [DynamoDBRangeKey]
        public string RecipeId { get; set; }

        public Recipe()
        {

        }

        public Recipe(CreateRecipe createRecipe)
        {
            this.Title = createRecipe.Title;
            this.Servings = createRecipe.Servings;
            this.Description = createRecipe.Description;
            this.Category = createRecipe.Category;
            this.PrepTime = createRecipe.PrepTime;
            this.CookTime = createRecipe.CookTime;
            this.Steps = createRecipe.Steps;
            this.IngredientGroups = createRecipe.IngredientGroups;
        }
    }
}
