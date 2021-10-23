using BlazorYoutubeDl.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BlazorYoutubeDl.Domain.ServiceInterfaces
{
    [ServiceContract]
    public interface IAuthService
    {
        Task<SignInResponce> SignUpAsync(SignUpRequest signUpRequest);
        Task<SignInResponce> SignInAsync(SignInRequest signInRequest);
        Task<string> GenerateUserNameAsync(string firstName, string lastName);
        string GetHashedPassword(string password);
    }
}
