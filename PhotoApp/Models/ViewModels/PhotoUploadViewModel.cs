using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoApp.Models.ViewModels {
    public class PhotoUploadViewModel {

        public HttpPostedFileBase File { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Album { get; set; }
    }
}