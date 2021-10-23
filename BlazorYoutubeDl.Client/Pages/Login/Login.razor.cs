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
    public partial class Login
    {
        private SignInRequest model = new SignInRequest();
        private bool loading;
        //private string test;

        [Inject]
        public IAccountService AccountService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async void OnValidSubmit()
        {
            loading = true;
            try
            {
                await AccountService.Login(model);
                NavigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                _ = ex;
                loading = false;
                StateHasChanged();
            }
        }

        private void ToSignUp()
        {
            NavigationManager.NavigateTo("/signup");
        }
    }
}
