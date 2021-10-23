using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using BlazorYoutubeDl.Domain.Validators;

namespace BlazorYoutubeDl.Domain.Models.Auth
{
    [DataContract]
    public class SignUpRequest
    {
        [DataMember(Order = 1)]
        [Required(ErrorMessage = "Please provide a firstname.")]
        public string Firstname { get; set; }

        [DataMember(Order = 2)]

        [Required(ErrorMessage = "Please provide a lastname.")]
        public string Lastname { get; set; }

        [DataMember(Order = 3)]

        [Required(ErrorMessage = "Please provide an Email")]
        [EmailAddress]
        public string Email {  get; set; }

        [DataMember(Order = 4)]

        [Required]
        [PasswordValidator]
        public string Password { get; set; }
    }
}
