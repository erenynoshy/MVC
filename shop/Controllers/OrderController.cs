using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace shop.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        projectDB db;
        
        public OrderController()
        {
            db = new projectDB();
          
        }

        public ActionResult Index()
        {
          //  var pro = db.OrderDatas.(i => i.Status == "waiting");
            var p = from a in db.OrderDatas
                    where a.Status == "waiting"
                    select a;
                var prodata = new List<Product>();
            
            foreach (var item in p)
            {
                prodata.Add(db.Products.FirstOrDefault(i => i.ProductID == item.ProductID));

            }
      
            return View(prodata);
        }
        [HttpGet]
        public ActionResult getAccepted()
        {
            //  var pro = db.OrderDatas.(i => i.Status == "waiting");
            var p = from a in db.OrderDatas
                    where a.Status == "accepted"
                    select a;
            var prodata = new List<Product>();

            foreach (var item in p)
            {
                prodata.Add(db.Products.FirstOrDefault(i => i.ProductID == item.ProductID));

            }

            return View(prodata);
        }
        [HttpGet]
        public ActionResult getRejected()
        {
            //  var pro = db.OrderDatas.(i => i.Status == "waiting");
            var p = from a in db.OrderDatas
                    where a.Status == "rejected"
                    select a;
            var prodata = new List<Product>();

            foreach (var item in p)
            {
                prodata.Add(db.Products.FirstOrDefault(i => i.ProductID == item.ProductID));

            }

            return View(prodata);
        }
        [HttpGet]
        public ActionResult Accept(int id )
        {
            var order = db.OrderDatas.FirstOrDefault(i => i.ProductID == id);
            order.Status = "accepted";
            db.SaveChanges();
           
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Reject(int id)
        {
            var order = db.OrderDatas.FirstOrDefault(i => i.ProductID == id);
    
            db.SaveChanges();
            ViewBag.status = "rejected";
            return RedirectToAction("Index");
        }
    }
}