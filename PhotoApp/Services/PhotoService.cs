using PhotoApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoApp.Services {
    public class PhotoService {

        private IRepository _repo;

        public PhotoService(IRepository repo) {
            _repo = repo;
        }

        public Album CreateAlbum(string title) {
            Album album = new Album {
                Title = title
            };

            _repo.Add<Album>(album);
            _repo.SaveChanges();

            return album;
        }

        public Photo CreatePhoto(string basePath, HttpPostedFileBase file, string title, string description) {
            var fileName = Path.Combine("Uploads", DateTime.Now.Ticks.ToString() + file.FileName.Substring(file.FileName.IndexOf('.')));

            file.SaveAs(Path.Combine(basePath, fileName));
            var photo = new Photo {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Description = description,
                Url = fileName
            };
            _repo.Add<Photo>(photo);
            _repo.SaveChanges();

            return photo;
        }

        public void AddPhotoToAlbum(string albumTitle, string photoId) {
            var album = (from a in _repo.Query<Album>().Include(a => a.Photos)
                        where a.Title == albumTitle
                        select a).SingleOrDefault();
            var photo = (from p in _repo.Query<Photo>()
                         where p.Id == photoId
                         select p).SingleOrDefault();

            album.Photos.Add(photo);
            _repo.SaveChanges();
        }

        public Album GetAlbumWithPhotos(string albumTitle) {
            return (from a in _repo.Query<Album>().Include(a => a.Photos)
                    where a.Title == albumTitle
                    select a).SingleOrDefault();
        }

        public IList<Album> ListAlbums() {
            return _repo.Query<Album>().ToList();
        }
    }
}