using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using NGUOIBAN.Models;

namespace NGUOIBAN.Controllers
{
    public class ProductController : Controller
    {
        private DBSportStore1 database= new DBSportStore1();
        // GET: Product
        public ActionResult Index()
        {
            var products = database.Products.Include(p => p.Category1);
            return View(products.ToList());

        }
        public ActionResult Create()
        {
            List<Category> list = database.Categories.ToList();
            ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", "");
            Product pro = new Product();
            return View(pro);
        }
       
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            List<Category> list = database.Categories.ToList();
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.ImagePro = "~/Content/images/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                database.Products.Add(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}