using System;
using System.Diagnostics.CodeAnalysis;

namespace FeedMe.Api.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class UnauthorizedRecipeAccessException : Exception
    {
        public UnauthorizedRecipeAccessException() : base($"Unauthorized access to a recipe resource") { }

        public UnauthorizedRecipeAccessException(string message) : base(message) { }

        public UnauthorizedRecipeAccessException(string message, Exception inner) : base(message, inner) { }
    }
}
