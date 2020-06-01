using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MinimalBlog.Controllers
{
    public class AuthController : Controller
    {
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
        public IActionResult Signup(string smtn)
        {
            return View();
        }
    }
}