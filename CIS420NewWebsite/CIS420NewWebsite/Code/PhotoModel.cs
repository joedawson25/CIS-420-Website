using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CIS420NewWebsite.Models;

namespace CIS420NewWebsite.Code
{
    public class PhotoModel : List<PhotoGallery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoModel"/> class.
        /// </summary>
        public PhotoModel(string folder)
        {
            string path = HttpContext.Current.Server.MapPath(folder);
            var di = new DirectoryInfo(path);

            foreach (var file in di.EnumerateFiles("*.jpg", SearchOption.TopDirectoryOnly))
            {
                var p = new PhotoGallery(string.Concat(folder, file.Name), Path.GetFileNameWithoutExtension(file.Name));
                Add(p);
            }
        }
    }
}