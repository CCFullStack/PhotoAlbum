using PhotoApp.Models;
using PhotoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoApp.Controllers
{
    public class AlbumController : Controller
    {
        private PhotoService _service;

        public AlbumController(PhotoService service) {
            _service = service;
        }

        // GET: Album
        public ActionResult Index()
        {
            return View(_service.ListAlbums());
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album) {
            
            _service.CreateAlbum(album.Title);

            return RedirectToRoute(new { Action = "Details", Controller = "Album", Id = album.Title });
        }
        
        public ActionResult Details(string id) {
            var album = _service.GetAlbumWithPhotos(id);

            return View(album);
        }
    }
}