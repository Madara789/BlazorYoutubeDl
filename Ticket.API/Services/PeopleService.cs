using Grpc.Core;
using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorYoutubeDl.Domain.GrpcMessages.Person;
using BlazorYoutubeDl.Domain.ServiceInterfaces;
using BlazorYoutubeDl.Utils;

namespace BlazorYoutubeDl.API.Services
{
    public class PeopleService : IPeopleService
    {
        private IList<Person> _peopleList;

        public PeopleService()
        {
            _peopleList = new List<Person>();
            for (int i = 0; i < 500; i++)
            {
                _peopleList.Add(new Person()
                {
                    Id = i, 
                    Bio = "Bio" + i,
                    FirstName = "Firstname" + i, 
                    LastName = "Lastname" + i,
                });
            }
        }
        
        public async ValueTask<PeopleReply> GetAll(GetAllPeopleRequest request, CallContext context = default)
        {
            //var test = context.ServerCallContext.GetHttpContext().User.GetUserID();
            //var user = await _userService.GetUserAsync(test);

            throw new RpcException(new(StatusCode.NotFound, "Some Text"), "Some Text");

            var reply = new PeopleReply();
            reply.Persons.AddRange(_peopleList);
            return await new ValueTask<PeopleReply>(reply);
        }

        public ValueTask<Person> GetPersonById(GetPersonByIdRequest request)
        {
            var result = (from x in _peopleList
                          where x.Id == request.Id
                          select x).FirstOrDefault();
            return new ValueTask<Person>(result);
        }
       
    }
}
