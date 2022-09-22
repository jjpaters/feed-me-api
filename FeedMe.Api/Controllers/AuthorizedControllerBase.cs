using Microsoft.AspNetCore.Mvc;

namespace FeedMe.Api.Controllers
{
    public class AuthorizedControllerBase : ControllerBase
    {
        public string Username
        {
            get
            {
                return this.User.Identity.Name;
            }
        }
    }
}

