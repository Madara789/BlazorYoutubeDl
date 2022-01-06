using BlazorYoutubeDl.Domain.GrpcMessages.Person;
using BlazorYoutubeDl.Domain.ServiceInterfaces;
using BlazorYoutubeDl.Services;
using Grpc.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorYoutubeDl.Client.Pages
{
    public partial class People
    {

        [Inject]
        public IPeopleService PersonService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        private string APIResult = "";
        private string GRPCResult = "";
        private string PersonResult = "";
        IList<Person> _peopleList;

        private async Task APIButtonClicked()
        {
            APIResult = "Loading...";
            await InvokeAsync(StateHasChanged);
            var startTime = DateTime.Now;
            if (_peopleList != null)
            {
                var elapsed = DateTime.Now.Subtract(startTime);
                APIResult = $"{_peopleList.Count} records returned via API in {elapsed.TotalMilliseconds} ms.";
                await InvokeAsync(StateHasChanged);
            }
        }

        private async Task GRPCButtonClicked()
        {
            try
            {
                GRPCResult = "Loading...";
                await InvokeAsync(StateHasChanged);
                var startTime = DateTime.Now;
                var list = await PersonService.GetAll(new GetAllPeopleRequest());
                if (list != null)
                {
                    _peopleList = list.Persons.ToList();
                    var elapsed = DateTime.Now.Subtract(startTime);
                    GRPCResult = $"{_peopleList.Count} records returned via gRPC in {elapsed.TotalMilliseconds} ms.";
                    await InvokeAsync(StateHasChanged);
                }
            }
            catch (RpcException ex)
            {
                _ = ex;
            }
            catch (Exception ex)
            {
                _ = ex;
                throw;
            }
        }

        async Task GRPCGetRandomPersonButtonClicked()
        {
            var obj = new object();
            var rnd = new Random(obj.GetHashCode());
            int RandomId = rnd.Next(1, 500);
            var request = new GetPersonByIdRequest { Id = RandomId };
            var person = await PersonService.GetPersonById(request);
            if (person != null)
            {
                PersonResult = $"{person.Id} {person.FirstName} {person.LastName}";
                await InvokeAsync(StateHasChanged);
            }

        }
    }
}
