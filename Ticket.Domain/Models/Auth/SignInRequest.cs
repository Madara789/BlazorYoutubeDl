using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace BlazorYoutubeDl.Domain.Models.Auth
{
    [DataContract]
    public class SignInRequest
    {
        [DataMember(Order = 1)]
        [Required(ErrorMessage = "Please provide a Username.")]
        public string UsernameOrEmail { get; set; }

        [DataMember(Order = 2)]
        [Required(ErrorMessage = "Please provide a Password.")]
        public string Password { get; set; }
    }
}
