using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace foodMenuCRUD.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        fooddbEntities db = new fooddbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<menuDetail> listMenu = db.menuDetails;
            return View(listMenu);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(menuDetail model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.menuDetails.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Invalid Operation");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Data");
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            menuDetail model = db.menuDetails.Find(id);
            return View("Create",model);
        }

        [HttpPost]
        public ActionResult Edit(menuDetail model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry<menuDetail>(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Invalid Operation");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Data");
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            menuDetail model = db.menuDetails.Find(id);
            if(model != null)
            {
                db.menuDetails.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}