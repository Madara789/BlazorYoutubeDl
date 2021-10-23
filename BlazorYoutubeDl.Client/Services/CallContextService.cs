using Grpc.Core;
using ProtoBuf.Grpc;
using System.Threading.Tasks;

namespace BlazorYoutubeDl.Services
{
    public interface ICallContextService
    {
        Task<CallOptions> CreateCallOptionsAuthHeader();
        Task<CallContext> CreateCallContextAuthHeader();
    }

    public class CallContextService : ICallContextService
    {
        private readonly ILocalStorageService _localStorageService;

        public CallContextService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<CallContext> CreateCallContextAuthHeader()
        {
            var options = await CreateCallOptionsAuthHeader();
            return new CallContext(options);
        }

        public async Task<CallOptions> CreateCallOptionsAuthHeader()
        {
            var token = await _localStorageService.GetItem<string>("token");

            var headers = new Metadata();
            headers.Add("Authorization", $"Bearer {token}");

            CallOptions options = new CallOptions(headers);

            return options;
        }
    }
}
