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
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            //var scheduler = new DHXScheduler(this);
            return View();
        }

        public JsonResult Data()
        {
            //Using Dxhtml JavaScript Edition (open source)
            var events = db.Events;

            var formatedEvents = new List<object>();
            foreach (var ev in events)
            {
                var formattingEvent = new
                {
                    id = ev.id,
                    start_date = ev.start_date.ToString(),
                    end_date = ev.end_date.ToString(),
                    //start_date = ev.start_date.Date.ToString("yyyy-MM-dd"),
                    //end_date = ev.end_date.Date.ToString("yyyy-MM-dd"),
                    text = ev.text
                };
                formatedEvents.Add(formattingEvent);
            }



            return Json(formatedEvents, JsonRequestBehavior.AllowGet);

            //Using Dxhtml MVC Scheduler Edition (free trial)
            //events for loading to scheduler
            //return new SchedulerAjaxData(_db.Events);
        }

        public ActionResult Save(string id, string text, string start_date, string end_date)
        {

            var existingEvent = db.Events.FirstOrDefault(e => e.id.ToString() == id);
            var newStartDate = Convert.ToDateTime(start_date);
            var newEndDate = Convert.ToDateTime(end_date);


            if (existingEvent != null)
            {
                existingEvent.start_date = newStartDate;
                existingEvent.end_date = newEndDate;
                existingEvent.text = text;
            }
            else
            {

                var newEvent = new Event()
                {
                    start_date = newStartDate,
                    end_date = newEndDate,
                    text = text
                };
                db.Events.Add(newEvent);
            }

            db.SaveChanges();



            return View("Index");
        }

        public ActionResult Delete(string id, string text, string start_date, string end_date)
        {

            var existingEvent = db.Events.FirstOrDefault(e => e.id.ToString() == id);
            var newStartDate = Convert.ToDateTime(start_date);
            var newEndDate = Convert.ToDateTime(end_date);

            if (existingEvent != null)
            {
                db.Events.Remove(existingEvent);
                db.SaveChanges();
            }

            return View("Index");
        }

    }
}
