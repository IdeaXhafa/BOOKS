using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BOOKS.Areas.Identity.Data;

namespace BOOKS.Controllers
{
    public class PerdoruesitController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        public PerdoruesitController(UserManager<ApplicationUser> userManager)
        {

            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = userManager.Users;
            return View(user);
        }
    }
}
