using BlazorYoutubeDl.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BlazorYoutubeDl.Domain.GrpcMessages.UserMessages
{
    [DataContract]
    public class UserMessage
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string FirstName { get; set; }

        [DataMember(Order = 3)]
        public string LastName { get; set; }

        [DataMember(Order = 4)]
        public string Email { get; set; }

        [DataMember(Order = 5)]
        public string Username { get; set; }

        [DataMember(Order = 6)]
        public byte[] Avatar { get; set; }

        [DataMember(Order = 7)]
        public bool HasDarkMode { get; set; }

       
    }
}
