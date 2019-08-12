using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPass.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPass.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            int? Count = HttpContext.Session.GetInt32("Count");
            // Count = (Count == null) ? 1 : Count;
            Count = 1;
            

            Random Rand = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string password = "";
            for (int i=0; i<14; i++){
                password = password + (chars[Rand.Next(0, chars.Length)]);
            }
            Count++;
            ViewBag.password = password;
            ViewBag.Count = Count;
            HttpContext.Session.SetInt32("Count", (int)Count);
            
            return View();

        }
    }
}
