using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementApp.Controllers
{
    public class ProductsAppController : Controller
    {
        //
        // GET: /ProductsApp/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

    }
}
