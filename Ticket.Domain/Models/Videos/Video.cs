using BlazorYoutubeDl.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorYoutubeDl.Domain.Models.Videos
{
    public class Video : Entity
    {
        public string Title {  get; set; }
        public string ThunmbnailUrl {  get; set; }
        public string Uploader {  get; set; }
        public string UploadSite {  get; set; }
        public string Url {  get; set; }
        public bool IsDownloaded { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
