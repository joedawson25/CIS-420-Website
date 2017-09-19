using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS420NewWebsite.Controllers
{
    public class AdministratorController : Controller
    {
        private Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        // GET: Administrator
        public ActionResult Index()
        {
            return View(db.Administrators.ToList());
        }
    }
}