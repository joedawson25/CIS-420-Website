using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS420NewWebsite.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public string PhotoName { get; set; }
        public string Description { get; set; }
        public byte[] Content { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}