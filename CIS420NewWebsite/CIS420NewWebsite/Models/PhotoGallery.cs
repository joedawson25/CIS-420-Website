﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS420NewWebsite.Models
{
    public class PhotoGallery
    {
        public string Path { get; set; }

        public string Description { get; set; }

        public PhotoGallery(string path, string description)
        {
            Path = path;
            Description = description;
        }
    }
}