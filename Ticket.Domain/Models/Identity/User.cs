using System.Collections.Generic;
using BlazorYoutubeDl.Domain.Models.Videos;

namespace BlazorYoutubeDl.Domain.Models.Identity
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] Avatar { get; set; }
        public string HashedPassword { get; set; }
        public bool HasDarkMode { get; set; }
        public string VideoPath { get; set; }
        public List<Video> Videos { get; set; }
    }
}