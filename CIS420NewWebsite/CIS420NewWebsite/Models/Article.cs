using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS420NewWebsite.Models
{
    // Create class to help MVC and VS and make our lives easier. Allows us to use as an IEnumerable type in the model
    // for the News Model. Allows for autocomplete. Holds the projected view from the WordPress feed for the controller.
    public class Article
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime PublicationDate { get; set; } 
    }
}