using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MinimalBlog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(string smt)
        {
            return View();
        }
    }
}