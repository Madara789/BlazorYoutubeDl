using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorYoutubeDl.Domain.Models;
using BlazorYoutubeDl.Domain.Models.Auth;
using BlazorYoutubeDl.Domain.Models.Identity;
using Grpc.Net.Client;
using BlazorYoutubeDl.Domain.ServiceInterfaces;
using ProtoBuf.Grpc.Client;

namespace BlazorYoutubeDl.Services
{
    public interface IAccountService
    {
        UserStore User { get; }
        bool isLoggedIn { get; }
        Task Initialize();
        Task Login(SignInRequest model);
        Task Logout();
        Task Register(SignUpRequest model);        
    }

    public class AccountService : IAccountService
    {        
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";
        private readonly IAuthService _authService;

        public UserStore User { get; private set; }

        public bool isLoggedIn => User is not null;

        public AccountService(
            
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            GrpcChannel channel
        ) {
            User = new UserStore();
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            _authService = channel.CreateGrpcService<IAuthService>();
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<UserStore>(_userKey);
        }

        public async Task Login(SignInRequest model)
        {
            var responce = await _authService.SignInAsync(model);
            var user = responce.User;

            if (User is null)
                User = new UserStore();

            User.Token = responce.Token;
            User.HasDarkMode = user.HasDarkMode;
            
            await _localStorageService.SetItem<UserStore>(_userKey, User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("/login");
        }

        public async Task Register(SignUpRequest model)
        {
            try
            {
                await _localStorageService.RemoveItem(_userKey);
                var response = await _authService.SignUpAsync(model);
                var user = response.User;

                if (User is null)
                    User = new UserStore();

                User.Token = response.Token;
                User.HasDarkMode = user.HasDarkMode;
                await _localStorageService.SetItem<UserStore>(_userKey, User);
            }
            catch (System.Exception ex)
            {
                _ = ex;

                throw;
            }
        }
    }
}