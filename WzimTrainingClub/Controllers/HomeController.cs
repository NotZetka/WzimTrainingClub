using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WzimTrainingClub.Models;

namespace WzimTrainingClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user != null)
            {
                ViewBag.Days = (DateTime.Now - user.CreatedOn).Days;
            }
            return View();
        }
    }
}
