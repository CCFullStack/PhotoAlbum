using PhotoApp.Models.ViewModels;
using PhotoApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoApp.Controllers
{
    public class PhotoController : Controller {

        private PhotoService _service;

        public PhotoController(PhotoService service) {
            _service = service;
        }

        // GET: Photo
        public ActionResult UploadPhoto(string albumName) {
            return View(model: albumName);
        }

        [HttpPost]
        public ActionResult UploadPhoto(PhotoUploadViewModel photo) {

            var p = _service.CreatePhoto(Server.MapPath("/"), photo.File, photo.Title, photo.Description);
            _service.AddPhotoToAlbum(photo.Album, p.Id);

            return RedirectToAction("Details", "Album", new { id = photo.Album });
        }
    }
}