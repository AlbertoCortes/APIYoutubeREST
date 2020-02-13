using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiYouTube.Models
{
    public class VideoAPI
    {
        public string  ID { get; set; }
        public string  Nombre { get; set; }
        public string  Url { get; set; }
        public string  Thumbnail { get; set; }
    }
}