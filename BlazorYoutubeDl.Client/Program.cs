using BlazorYoutubeDl.Services;
using BlazorYoutubeDl.Domain.ServiceInterfaces;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;

namespace BlazorYoutubeDl.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton(service =>
            {
                // First we need a special Web Handler
                var handler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());
                // Next we create a channel from the base address and a custom HttpClient based on the handler
                var channel = GrpcChannel.ForAddress(new Uri("https://localhost:44366"), new GrpcChannelOptions() { HttpClient = new HttpClient(handler) });

                return channel;
            });

            builder.Services
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<ICallContextService, CallContextService>()
                .AddScoped<IPeopleService, PeopleService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddScoped(sp => new HttpClient());

            builder.Services.AddMudServices();            

            var host = builder.Build();

            var accountService = host.Services.GetRequiredService<IAccountService>();
            await accountService.Initialize();

            await host.RunAsync();
        }
    }
}
