using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        public AuthController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(User model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            List<string> errors = userRepository.Create(model);
            if (errors != null)
            {
                foreach(var error in errors)
                    ModelState.AddModelError("", error);
                return View(model);
            }
            return RedirectToAction("Index","Home");
        }
    }
}