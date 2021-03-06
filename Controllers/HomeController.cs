using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace RandomPasscode.Controllers

{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route ("")]
        public IActionResult Index ()
        {
            int? count = HttpContext.Session.GetInt32("count");
            if(count == null)
            {
                count = 0;
            }
            count = count + 1;
            string result = "";
            string letterlist = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string newcode = "";
            Random rand = new Random();
            for(var i = 0; i < 14; i++)
            {
                newcode = newcode +letterlist[rand.Next(0,letterlist.Length)];
            }
            ViewBag.newcode = newcode;
            ViewBag.CountNumber = count;
            HttpContext.Session.SetInt32("count", (int)count);
            return View();
            
        }

    }
}