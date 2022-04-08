using Microsoft.AspNetCore.Mvc;

namespace FeedMe.Api.Controllers
{
    public class ProtectedControllerBase : ControllerBase
    {
        public string UserIdentity
        {
            get { return User.Identity.Name; }
        }
    }
}
