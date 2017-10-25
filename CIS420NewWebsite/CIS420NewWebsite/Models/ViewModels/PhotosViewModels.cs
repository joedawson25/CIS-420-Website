using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIS420NewWebsite.Models
{
    public class PhotoUploadViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Photo Name")]
        public string PhotoName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageData { get; set; }
        
    }
}