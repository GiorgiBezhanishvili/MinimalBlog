using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinimalBlog.ViewModels;
using Services.Contracts;

namespace MinimalBlog.Controllers
{
    [Authorize]
    public class DBoardController : Controller
    {
        private readonly IUnitOfWork _service;
        private readonly UserManager<User> _userManager;

        public DBoardController(IUnitOfWork service,UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public IActionResult Dashboard()
        {

            var userId = _userManager.GetUserId(HttpContext.User);

            var posts = _service.Post.GetAllPostsByAuthorId(userId);

            var fullName = _service.User.GetUserFullName(userId);
            ViewBag.FullName = fullName;
            return View(posts);
        }

        //[HttpPost]
        //public IActionResult Dashboard(string smt)
        //{
        //    return View();
        //}

        public IActionResult Createpost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Createpost(NewPostVM model)
        {

            if (ModelState.IsValid) 
            {
                var userId = _userManager.GetUserId(HttpContext.User);

                Post post = new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    Thumb = model.Thumb,
                    Category = model.Category,
                    Date = DateTime.Now,
                    AuthorId = userId
                };

                _service.Post.Create(post);
                _service.Commit();
                return RedirectToAction("Dashboard");
            }

            return View(model);
        }

    }
}