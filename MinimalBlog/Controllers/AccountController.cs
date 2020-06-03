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
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model,string returnUrl) 
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else 
                    {
                        return RedirectToAction("Dashboard", "DBoard");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index","home");
        }

        [HttpGet]
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

                    //for username
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
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