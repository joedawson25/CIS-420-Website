using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIS420NewWebsite.Models;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace CIS420NewWebsite.Controllers
{
    public class PhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Photos
        public ActionResult Index()
        {
            var photoList = db.Photos.Select(x => new PhotoUploadViewModel
            {
                ID = x.ID,
                PhotoName = x.PhotoName,
                Description = x.Description,
                ImageData = new MemoryPostedFile(x.Content, x.PhotoName) // from tyler
            });
            return View(db.Photos.ToList());
        }

        // GET: Photos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            return View();
        }

        #region ImageParsing
        public byte[] ImagetoByteArray(string path)
        {
            Image image = Image.FromFile(path);
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }

        public Image ByteArraytoImage(byte[] imageByteArray)
        {
            return Image.FromStream(new MemoryStream(imageByteArray));
        }
        #endregion  

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(PhotoUploadViewModel photoUpload)
        public async Task<ActionResult> Create(PhotoUploadViewModel photoUpload)
        {
            byte[] imageContent = null;
            if (photoUpload.ImageData == null)
            {
                ModelState.AddModelError("ImageData", "You must select an image to upload.");
            }
            else if ((imageContent = ToByteArray(photoUpload.ImageData.InputStream)) == null)
            {
                ModelState.AddModelError("ImageData", "The file you uploaded is not an acceptable type of image.");
            }
            else
            {
                imageContent = ImagetoByteArray(photoUpload.ImageData.FileName);
            }

            if (ModelState.IsValid)
            {
                var photo = new Photo
                {
                    Content = imageContent,
                    ContentLength = photoUpload.ImageData.ContentLength,
                    ContentType = photoUpload.ImageData.ContentType,
                    PhotoName = photoUpload.PhotoName,
                    Description = photoUpload.Description,
                    DateUploaded = DateTime.UtcNow,

                };
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(photoUpload);
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhotoName,Description,ContentLength,ContectType,DateUploaded")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public Image ToImage(Stream inputStream, bool useEmbeddedColorManagement = true, bool validateImageData = true)
        {
            Image result = null;
            try
            {
                result = Image.FromStream(stream: inputStream, useEmbeddedColorManagement: useEmbeddedColorManagement, validateImageData: validateImageData);
            }
            catch (Exception e)
            {
                // Log exception
            }
            return result;
        }

        public byte[] ToByteArray(Stream inputStream)
        {
            return ToByteArray(ToImage(inputStream));
        }

        public byte[] ToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
