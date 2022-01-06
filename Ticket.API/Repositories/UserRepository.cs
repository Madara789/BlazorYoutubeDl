using BlazorYoutubeDl.Domain.Exeptions;
using BlazorYoutubeDl.Domain.Models.Identity;
using BlazorYoutubeDl.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static BlazorYoutubeDl.Utils.CastUtils;

namespace BlazorYoutubeDl.Api.Repositories
{
    public class UserRepository : IUserRepository
    {

        public UserRepository()
        {
        }

        public async Task CreateUserAsync(User user)
        {
        }

        public Task DeleteUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var userList = new List<User>();

            return userList;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return new User();
        }

        public Task<User> UpdateUserAsnyc(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
