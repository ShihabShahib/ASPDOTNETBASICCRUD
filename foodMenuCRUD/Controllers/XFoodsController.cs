using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace foodMenuCRUD.Controllers
{
    public class XFoodsController : Controller
    {
        // GET: XFoods
        [HttpGet]
        public ActionResult loginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult loginAdmin(FormCollection values)
        {
            if (values["username"] == "admin" && values["password"] == "12345678")
            {
                return RedirectToAction("Index", "Menu");
            }
            else
            {
                ViewBag.msg = "Invalid";
                return View();
            }
        }
    }
}