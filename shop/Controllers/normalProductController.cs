
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shop.Controllers
{
    public class normalProductController : Controller
    {
        // GET: normalProduct
        projectDB db;
        public normalProductController()
        {
            db = new projectDB();
        }
        // GET: Product
        public ActionResult Index()
        {
            var pro = db.Products.ToList();
            return View(pro);
        }
        public ActionResult GetAll()
        {
            var pro = db.Products.ToList();
            return View(pro);
        }
        [HttpGet]
        public ActionResult AddOrder(int id)
        {
            if (Session["user_name"] != null)
            {
                var uname = Session["user_name"].ToString();
                var uid = db.Users.FirstOrDefault(i => i.UserName == uname);
                OrderData d = new OrderData();
                d.ProductID = id;
                d.UserID = uid.UserID;
                d.Status = "waiting";
                //d.Time = new DateTime();
                //  d.Time = new DateTime();

                var pro = db.OrderDatas.Add(d);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "login");
            }

        }
    }
}