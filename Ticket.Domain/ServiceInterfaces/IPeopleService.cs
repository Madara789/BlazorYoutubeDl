using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BlazorYoutubeDl.Domain.GrpcMessages.Person;

namespace BlazorYoutubeDl.Domain.ServiceInterfaces
{
    [ServiceContract]
    public interface IPeopleService
    {
        ValueTask<PeopleReply> GetAll(GetAllPeopleRequest request, CallContext context = default);
        ValueTask<Person> GetPersonById(GetPersonByIdRequest request);
    }
}