using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIS420NewWebsite.Models;

namespace CIS420NewWebsite.Controllers
{
    public class CalendarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Calendar
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }


        // GET: Calendar/Edit/5
        public ActionResult Edit(string id, string titleText)
        {
            var eventToModify = db.Events.FirstOrDefault(ev => ev.id.ToString() == id);

            eventToModify.text = titleText;
            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        
    }

    
}
