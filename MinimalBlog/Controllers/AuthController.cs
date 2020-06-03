using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinimalBlog.ViewModels;

namespace MinimalBlog.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AuthController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string somthing) 
        {
            return View();
        }

        public IActionResult Signup() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Picture = "nothingyet",
                    Email = model.Email,
                    PasswordHash = model.Password,

                    //for gachumeba
                    UserName = "Nothing"
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                }
            }

            return View(model);
        }
    }
}