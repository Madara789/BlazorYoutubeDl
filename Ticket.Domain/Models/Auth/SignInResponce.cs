
using BlazorYoutubeDl.Domain.GrpcMessages.UserMessages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BlazorYoutubeDl.Domain.Models.Auth
{
    [DataContract]
    public class SignInResponce
    {
        [DataMember(Order = 1)]
        public UserMessage User { get; set; }
        //public IList<CompanyDTO> Companies { get; set; }
        [DataMember(Order = 2)]
        public string Token { get; set; }
    }
}
