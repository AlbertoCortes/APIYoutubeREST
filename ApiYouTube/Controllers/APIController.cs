using ApiYouTube.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiYouTube.Controllers
{
    public class APIController : ApiController
    {
        public List<VideoAPI> Get(string name)
        {
                List<VideoAPI> videos = new List<VideoAPI>();
                YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer
                {
                    ApiKey = "AIzaSyBhqe3OaIZT7RusiHlV_kBL3z2CExG3Vb4",
                    ApplicationName = "Rockola-264715"
                });
                SearchResource.ListRequest searchListRequest = youtube.Search.List("snippet");
                searchListRequest.Q = name;
                searchListRequest.MaxResults = 40;
                SearchListResponse searchListResponse = searchListRequest.Execute();
                foreach (var item in searchListResponse.Items)
                {
                    if (item.Id.Kind == "youtube#video")
                    {
                        videos.Add(new VideoAPI
                        {
                            ID = item.Id.VideoId,
                            Nombre = item.Snippet.Title,
                            Url = "https://www.youtube.com/embed/" + item.Id.VideoId,
                            Thumbnail = "http://img.youtube.com/vi/" + item.Id.VideoId + "/hqdefault.jpg"
                        });
                    }
                }
                return videos;
            }
    }
}
