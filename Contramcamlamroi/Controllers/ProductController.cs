using Contramcamlamroi.Models;
using PagedList;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq; 
using System.Web.Mvc;

namespace Contramcamlamroi.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DBSportStoreEntities1 database = new DBSportStoreEntities1();
        public ActionResult SearchOption(double min = double.MinValue, double max = double.MaxValue)
        {
            var list = database.Products.Where(p => (double)p.Price >= double.MinValue && (double)p.Price <= max).ToList();
            return View(list);
        }
        public ActionResult Index(string category, int? page, double min = double.MinValue, double max = double.MaxValue)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            if (category == null)
            {
                var productList = database.Products.OrderByDescending(x => x.NamePro);
                return View(productList.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var productList = database.Products.OrderByDescending(x => x.Category).Where(x => x.Category == category);
                return View(productList.ToPagedList(pageNum, pageSize));
                
            }

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
        public ActionResult Edit(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Product name)
        {
            database.Entry(name).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index_Admin");
        }

        public ActionResult Details(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
        public ActionResult Delete(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            try
            {
                pro = database.Products.Where(s => s.ProductID == id).FirstOrDefault();
                database.Products.Remove(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        public ActionResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = database.Categories.ToList<Category>();
            return PartialView(se_cate);
        }
        public ActionResult Index_Admin(string _name)
        {
            if (_name == null)
                return View(database.Products.ToList());
            else
                return View(database.Products.Where(s => s.NamePro.Contains(_name)).ToList());

        }
        public ActionResult ProductList(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
        public ActionResult Search(string _name)
        {
            if (_name == null)
                return View(database.Products.ToList());
            else
                return View(database.Products.Where(s => s.NamePro.Contains(_name)).ToList());


        }
        public ActionResult Vourcher( int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
    }
}