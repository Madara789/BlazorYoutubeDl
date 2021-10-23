using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorYoutubeDl.Domain.Models.Identity
{
    public class UserStore
    {
        public bool HasDarkMode { get; set; }
        public string Token { get; set; }
    }
}
