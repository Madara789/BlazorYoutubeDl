using BlazorYoutubeDl.Domain.Models.Auth;
using BlazorYoutubeDl.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorYoutubeDl.Client.Pages.Login
{
    public partial class SignUp
    {
        private SignUpRequest user;
        public string LoginMesssage { get; set; }

        private bool loading;

        [Inject]
        public IAccountService AccountService { get; set; }

        protected override Task OnInitializedAsync()
        {
            user = new SignUpRequest();
            return base.OnInitializedAsync();
        }

        private async Task RegisterUser()
        {
            loading = true;
            try
            {
                await AccountService.Register(user);
                NavigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                loading = false;
                StateHasChanged();
            }
        }
    }
}
