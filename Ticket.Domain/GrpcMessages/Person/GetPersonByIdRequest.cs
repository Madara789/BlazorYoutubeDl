using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlazorYoutubeDl.Domain.GrpcMessages.Person
{
    [DataContract]
    public class GetPersonByIdRequest
    {
        [DataMember(Order = 1)] 
        public int Id { get; set; }
    }
}
