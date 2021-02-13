using HRManagmentBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRManagmentBO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataContext db = new DataContext();
        Functions function = new Functions();
        public ActionResult Index()
        { 
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                BOUsers user = (BOUsers)Session["User"];

                if (!function.HasPermission(1, user) )
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }



        
    }
}