using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        projectDB db;
        public HomeController()
        {
            db = new projectDB();
        }
        public ActionResult Index()
        {
            if (Session["user_name"] == null)
            {
                return RedirectToAction("index", "normalProduct");
            }
            else
            {
                var type = Session["user_name"].ToString();
                var u = db.Users.FirstOrDefault(i => i.UserName == type);
               
                if (u.userType == "admin     ")
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    return RedirectToAction("Index", "normalProduct");
                }
            }
            
        }

        public ActionResult Register()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout()
        {
            Session["user_name"] = null;

            return RedirectToAction("index", "normalProduct");
        }
    }
}