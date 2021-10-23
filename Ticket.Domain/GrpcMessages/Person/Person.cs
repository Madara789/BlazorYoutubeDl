using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlazorYoutubeDl.Domain.GrpcMessages.Person
{
    [DataContract]
    public class Person
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string FirstName { get; set; } = "";
        [DataMember(Order = 3)]
        public string LastName { get; set; } = "";
        [DataMember(Order = 4)]
        public string Bio { get; set; } = "";
        [DataMember(Order = 5)]
        public string PhotoUrl { get; set; } = "generic-person.png";
    }
}
