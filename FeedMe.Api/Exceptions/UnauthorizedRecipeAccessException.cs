using System;

namespace FeedMe.Api.Exceptions
{
    public class UnauthorizedRecipeAccessException : Exception
    {
        public UnauthorizedRecipeAccessException() : base($"Unauthorized access to a recipe resource") { }

        public UnauthorizedRecipeAccessException(string message) : base(message) { }

        public UnauthorizedRecipeAccessException(string message, Exception inner) : base(message, inner) { }
    }
}
