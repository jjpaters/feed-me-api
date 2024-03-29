﻿using Amazon.DynamoDBv2.DataModel;
using FeedMe.Api.Configuration;
using System.Collections.Generic;

namespace FeedMe.Api.Models.Recipes
{
    public class CreateRecipe
    {
        public string Title { get; set; }

        public int Servings { get; set; }

        public string Description { get; set; }

        public RecipeCategories Category { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        [DynamoDBProperty(typeof(DynamoJsonSerializeConverter<IList<Step>>))]
        public IList<Step> Steps { get; set; }

        [DynamoDBProperty(typeof(DynamoJsonSerializeConverter<IList<IngredientGroup>>))]
        public IList<IngredientGroup> IngredientGroups { get; set; }

        public string Notes { get; set; }
    }
}
