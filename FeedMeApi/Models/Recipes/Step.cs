namespace FeedMeApi.Models.Recipes
{
    /// <summary>
    /// Step Object
    /// </summary>
    public class Step
    {
        /// <summary>
        /// Order to follow in the recipe
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Step text
        /// </summary>
        public string Text { get; set; }
    }
}
