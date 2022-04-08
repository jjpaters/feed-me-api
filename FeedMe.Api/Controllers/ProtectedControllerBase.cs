using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FeedMe.Api.Controllers
{
    public class ProtectedControllerBase : ControllerBase
    {
        public string UserIdentity
        {
            get 
            {
                return this.User.FindFirst(ClaimTypes.NameIdentifier).Value.Split("|")[1];
            }
        }
    }
}
