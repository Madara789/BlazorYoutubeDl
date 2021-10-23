using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlazorYoutubeDl.Domain.GrpcMessages.Person
{
    [DataContract]
    public class PeopleReply
    {
        [DataMember(Order = 1)]
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
