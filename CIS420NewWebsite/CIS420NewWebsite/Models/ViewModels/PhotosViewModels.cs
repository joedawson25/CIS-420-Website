using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace CIS420NewWebsite.Models
{
    public class PhotoUploadViewModel
    {
        public int ID { get; set; }

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

// from tyler
public class MemoryPostedFile : HttpPostedFileBase
{
    private readonly byte[] fileBytes;

    public MemoryPostedFile(byte[] fileBytes, string fileName = null)
    {
        this.fileBytes = fileBytes;
        this.FileName = fileName;
        this.InputStream = new MemoryStream(fileBytes);
    }

    public override int ContentLength => fileBytes.Length;

    public override string FileName { get; }

    public override Stream InputStream { get; }
}