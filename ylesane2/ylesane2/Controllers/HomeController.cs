using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ylesane2.Models;

namespace ylesane2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            DataBaseContext db = new DataBaseContext();
            ViewBag.user = db.Users;
            ViewBag.products = db.Products;
            //ViewBag.user = db.Users.Where(x => x.login == "admin").FirstOrDefault();
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Title = "Register Page";
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";
            return View();
        }

        public ActionResult Logoff()
        {
            Session.Clear();
            DataBaseContext db = new DataBaseContext();
            ViewBag.user = db.Users;
            ViewBag.products = db.Products;

            return View("index");
        }

        public ActionResult Profile()
        {
            DataBaseContext db = new DataBaseContext();
            ViewBag.user = db.Users;
            ViewBag.Title = "Profile Page";
            ViewBag.Data = db.Services.ToList().Where(x => x.Email == (string)Session["Email"]);
            return View();
        }

        public ActionResult Products()
        {
            DataBaseContext db = new DataBaseContext();
            ViewBag.products = db.Products;
            ViewBag.Title = "Products Page";
            return View();
        }
    }
}
