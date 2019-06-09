using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            this._signInManager = signInManager;
        }

        [HttpPost("Signout")]
        public IActionResult SignOut()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                this._signInManager.SignOutAsync().Wait();
            }

            return Ok();
        }
    }
}