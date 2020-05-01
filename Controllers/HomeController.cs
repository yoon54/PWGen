using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPassword.Models;

namespace RandomPassword.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            int? counter =  HttpContext.Session.GetInt32("counter");
            if(counter == null)
            {
                counter = 1;
                HttpContext.Session.SetInt32("counter", (int) counter);
            }
            else
            {
                counter ++;
                HttpContext.Session.SetInt32("counter", (int) counter);
            }
            Dictionary<string, object> model = new Dictionary<string, object>();
            model["counter"] = (int) counter;
            model["passcode"] = new Password().Value;
            return View(model);
        }
        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

    }
}