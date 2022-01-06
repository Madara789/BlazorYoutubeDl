using Grpc.Net.Client;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;
using System.Threading.Tasks;
using BlazorYoutubeDl.Domain.GrpcMessages.Person;
using BlazorYoutubeDl.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace BlazorYoutubeDl.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleService _peopleService;
        private readonly ICallContextService _callContextService;

        public PeopleService(GrpcChannel channel, ICallContextService callContextService)
        {
            _callContextService = callContextService;
            _peopleService = channel.CreateGrpcService<IPeopleService>();
        }

        [AllowAnonymous]
        public async ValueTask<PeopleReply> GetAll(GetAllPeopleRequest request, CallContext context = default)
        {
            var callContext = context;

            if (callContext.Equals(CallContext.Default))
                callContext = await _callContextService.CreateCallContextAuthHeader();

            return await _peopleService.GetAll(request, callContext);
        }

        [AllowAnonymous]
        public async ValueTask<Person> GetPersonById(GetPersonByIdRequest request)
        {
            return await _peopleService.GetPersonById(request);
        }
    }
}
