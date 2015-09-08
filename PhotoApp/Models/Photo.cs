using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoApp.Models {
    public class Photo {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Album Album { get; set; }
        public double Rating { get; set; }
    }
}