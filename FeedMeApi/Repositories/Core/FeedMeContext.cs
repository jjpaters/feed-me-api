using Microsoft.EntityFrameworkCore;

namespace FeedMeApi.Repositories.Core
{
    public class FeedMeContext : DbContext
    {
        public FeedMeContext(DbContextOptions<FeedMeContext> options) : base(options) { }

        public DbSet<Models.Recipes.Recipe> UserRecipes { get; set; }

        public DbSet<Models.Recipes.Ingredient> UserIngredients { get; set; }

        public DbSet<Models.Recipes.Step> UserSteps { get; set; }
    }
}
