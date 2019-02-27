using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecianBP.Db;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(DbService context) : base(context) { }

        [Route("{*queryString}")]
        public IActionResult Index(string queryString = null)
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
