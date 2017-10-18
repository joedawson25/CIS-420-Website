using CIS420NewWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CIS420NewWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       
        public ActionResult Events()
        {
           
            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }
        public ActionResult History()
        {
            return View();
        }
        //News controller updated. Pull feed from HBPA National Site
        public async Task<ActionResult> News()
        {
            // https://stackoverflow.com/questions/11194757/consuming-wordpress-rss-feed-in-asp-net Site for reference

            // GetAsync is a promise to provide something; 
            // keyword "await" tells the application to await the data before moving on.
            var response = await new HttpClient().GetAsync("https://nationalhbpa.com/category/kentucky-hbpa/feed/");
            var content = await response.Content.ReadAsStringAsync(); // Convert from bits to text
            var posts = XDocument.Parse(content).Descendants("item")
                .Select(post => new Article
                 {
                     Title = post.Element("title").Value,
                     Link = post.Element("link").Value,
                     PublicationDate = DateTime.Parse(post.Element("pubDate").Value)
                 });

            return View(posts); // Becomes available to the view.

        }

        [Authorize]
        public ActionResult Documents()
        {
            return View();
        }
        public ActionResult RaceInfo()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult LocalNews()
        {
            return View();
        }
    }
}