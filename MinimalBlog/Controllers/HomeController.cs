using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinimalBlog.Models;
using Services.Contracts;

namespace MinimalBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _service;

        public HomeController(ILogger<HomeController> logger,UserManager<User> userManager,IUnitOfWork service)
        {
            _logger = logger;
            _userManager = userManager;
            _service = service;
        }

        public IActionResult Index()
        {
            var allPostst = _service.Post.GetAll();

            foreach (var post in allPostst)
            {
                var id = post.AuthorId;
                var user = _service.User.GetUserById(id);
                post.Author = user;
            }

            var userId = _userManager.GetUserId(HttpContext.User);
            if (userId == null)
            {
                return View(allPostst);
            }

            
            var fullName = _service.User.GetUserFullName(userId);
            ViewBag.FullName = fullName;
            return View(allPostst);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
