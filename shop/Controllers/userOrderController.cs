
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shop.Controllers
{
    public class userOrderController : Controller
    {
        projectDB db;

        public userOrderController()
        {
            db = new projectDB();

        }
        public ActionResult Index()
        {
            //  var pro = db.OrderDatas.(i => i.Status == "waiting");
            var accept = from a in db.OrderDatas
                         where a.Status == "accepted"
                         select a;
            //var reject = from a in db.OrderDatas
            //             where a.Status == "rejected"
            //             select a;
            var prodata = new List<Product>();

            foreach (var item in accept)
            {
                prodata.Add(db.Products.FirstOrDefault(i => i.ProductID == item.ProductID));

            }
            //foreach (var item in reject)
            //{
            //    prodata.Add(db.Products.FirstOrDefault(i => i.ProductID == item.ProductID));

            //}
            return View(prodata);
        }
        public ActionResult rejected()
        {

            var accept = from a in db.OrderDatas
                         where a.Status == "rejected"
                         select a;

            var prodata = new List<Product>();

            foreach (var item in accept)
            {
                prodata.Add(db.Products.FirstOrDefault(i => i.ProductID == item.ProductID));

            }

            return View(prodata);
        }
  

    }
}