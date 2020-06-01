using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MinimalBlog.Controllers
{
    public class DBoardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Dashboard(string smt)
        {
            return View();
        }

        public IActionResult Createpost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Createpost(string smt)
        {
            return View();
        }

    }
}