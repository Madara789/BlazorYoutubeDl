using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorYoutubeDl.Domain.Models.Auth;
using BlazorYoutubeDl.Domain.Models.Identity;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using BlazorYoutubeDl.API.Helpers;
using Microsoft.Extensions.Options;
using BlazorYoutubeDl.Utils;
using BlazorYoutubeDl.Domain.Exeptions;
using Microsoft.AspNetCore.Http;
using BlazorYoutubeDl.Domain.ServiceInterfaces;
using BlazorYoutubeDl.Domain.RepositoryInterfaces;
using BlazorYoutubeDl.Domain.GrpcMessages.UserMessages;


namespace BlazorYoutubeDl.API.Services
{    
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public AuthService(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }

        public async Task<SignInResponce> SignUpAsync(SignUpRequest signUpRequest)
        {
            //// validate company name
            ////if ((await _companyService.CompanyNameAvailableAsync(signUpRequest.CompanyName)) is false)
            ////    throw new HttpStatusException(StatusCodes.Status409Conflict, "A company with this name is already existing.");

            //// create new user
            //User newUser = new User()
            //{
            //    Email = signUpRequest.Email,
            //    FirstName = signUpRequest.Firstname,
            //    LastName = signUpRequest.Lastname,
            //    HasDarkMode = false
            //};

            //// generate username
            //newUser.Username = await GenerateUserNameAsync(newUser.FirstName, newUser.LastName);

            //// password hashed by BCrypt with workFactor of 11 => round about 150-300 ms depends on hardware.
            //newUser.HashedPassword = GetHashedPassword(signUpRequest.Password);            

            //await _userRepository.CreateUserAsync(newUser);

            //// generate token
            //var token = CreateToken(newUser);

            
            //return new SignInResponce()
            //{
            //    User = AssembleUserMessage(newUser),
            //    Token = token
            //};
            throw new NotImplementedException();
        }

        public async Task<SignInResponce> SignInAsync(SignInRequest signInRequest)
        {
            //// find user with username
            //var user = GetUserByUsername(signInRequest.UsernameOrEmail);

            //if (user is null)
            //    throw new HttpStatusException(StatusCodes.Status400BadRequest, "Cannot signIn."); // generic message in order to not let the clients know what is wrong.

            //// verify password
            //if (!BCrypt.Net.BCrypt.Verify(signInRequest.Password, user.HashedPassword))
            //    throw new HttpStatusException(StatusCodes.Status400BadRequest, "Cannot signIn."); // generic message in order to not let the clients know what is wrong.

            var user = new User()
            {
                Id = 1,
                FirstName = "Test",
            };

            // Generate Token
            var token = CreateToken(user);

            return new SignInResponce()
            {
                User = AssembleUserMessage(user),
                Token = token
            };
            throw new NotImplementedException();   
        }

        private UserMessage AssembleUserMessage(User user)
        {
            UserMessage userMessage = new UserMessage()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                HasDarkMode = user.HasDarkMode,
                Username = user.Username,
                Avatar = user.Avatar,
            };

            return userMessage;
        }

        /// <summary>
        /// Creates a JWT-Token issued for the provided user.
        /// </summary>
        /// <param name="user">The Subject the token will be issued for</param>
        /// <returns>A JWT-Token with all user claims.</returns>
        private string CreateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenHandler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }

        ///// <summary>
        ///// Generates a unique Username, based of the Firstname and the Lastname. If the Firstname letters are not enough to build a unique name, use numbers at the end of the Username.
        ///// </summary>
        ///// <param name="firstName">Firstname</param>
        ///// <param name="lastName">Lastname</param>
        ///// <returns>Unique Username with Firstname+Lastname plus number suffix if needed.</returns>
        //public async Task<string> GenerateUserNameAsync(string firstName, string lastName)
        //{
        //    int index = 0;
        //    string username;

        //    do
        //    {
        //        index++;

        //        if (index < firstName.Length)
        //            username = firstName.Substring(0, index) + lastName;
        //        else
        //            username = firstName + lastName + index.ToString();

        //        // Max 1000 users with same name and number suffix... enough for project 2...
        //        if (index > 1000) throw new HttpStatusException(StatusCodes.Status500InternalServerError, "Username cannot be generated.");
        //    }
        //    while (UsernameAvailableAsync(username) is false);

        //    return username;
        //}

        public string GetHashedPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public Task<string> GenerateUserNameAsync(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
