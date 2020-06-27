using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace shop.Controllers
{
    public class ProductController : Controller
    {
        projectDB db;
        public ProductController()
        {
            db = new projectDB();
        }
        // GET: Product
        public ActionResult Index()
        {
            var pro = db.Products.ToList();
            return View(pro);
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var pro = db.Products.ToList();
            return View(pro);
        }
        [HttpGet]
        public ActionResult getCreatesection()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Product p,HttpPostedFileBase file)
        {
          //  string filename = Path.GetFileName(file.FileName);
            if(file!=null && file.ContentLength>0)
            {
                string filename = Path.GetFileName(file.FileName);
                string fileext = Path.GetExtension(filename);
                if(fileext==".jpg"||fileext==".png")
                {
                    string filepath =Server.MapPath("/productimgs/"+ filename);
                    file.SaveAs(filepath);
                    p.ImagePath = filename;
                    if (ModelState.IsValid)
                    {
                        db.Products.Add(p);
                        db.SaveChanges();
                        //remain  the name of the controller 
                        return RedirectToAction("Index");
                    }
                }
            }
          //  p.Image = filename;
          
            return Content("!!!!");
        }
        [HttpGet]
        public ActionResult Edit(int id )
        {
            var product = db.Products.FirstOrDefault(i => i.ProductID == id);
            
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            db.Products.Remove(db.Products.FirstOrDefault(i => i.ProductID == id));
            db.OrderDatas.Remove(db.OrderDatas.FirstOrDefault(l => l.ProductID == id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}