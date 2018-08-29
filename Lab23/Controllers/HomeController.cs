using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab23.Models;

namespace Lab23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            CoffeeShopDBEntities oRM = new CoffeeShopDBEntities();
            
            return View(oRM.Items.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult SaveRecord(User model)
        {
            CoffeeShopDBEntities oRM = new CoffeeShopDBEntities(); 

            User user = new User();
            user.firstName = model.firstName;
            user.lastName = model.lastName;
            user.email = model.email;
            user.phoneNumber = model.phoneNumber;
            user.passWord = model.passWord;
            int lastestuserId = user.userId;

            oRM.Users.Add(user);
            oRM.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}