using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS420NewWebsite.Controllers
{
    public class MemberController : Controller
    {
        private CIS420NewWebsite.Models.ApplicationDbContext db = new CIS420NewWebsite.Models.ApplicationDbContext();
        // GET: Member
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }


    }
}