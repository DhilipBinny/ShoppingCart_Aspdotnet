using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S_cart.Models;

namespace S_cart.Controllers
{
    public class PartialViewsController : Controller
    {
        // GET: PartialViews
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViews(string page, string fname, string lname)
        {
            ////initializing a User object and setting values - test data
            //User user = new User();
            //user.Id = 1;
            //user.FirstName = "first name"; 
            //user.LastName = "last name";
            //user.Username = "username"; 
            //user.Password = "password";
            //user.SessionId = "123";
            //ViewData["first"] = (string)user.FirstName;
            //ViewData["last"] = (string)user.LastName;

            ViewData["user"] = fname + " " + lname;

            //using ViewData, pass the object with parameter to view

            ViewData["type"] = page; 
            return View();
        }
    }
}