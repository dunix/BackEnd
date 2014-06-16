using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRole1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return Redirect("~/Administrador");

            }
            else if (User.IsInRole("instructor"))
            {
                return Redirect("~/Instructor");
            }
            else if (User.IsInRole("cliente"))
            {
                return Redirect("~/Clientes");
            }
            else {
                return View();
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}