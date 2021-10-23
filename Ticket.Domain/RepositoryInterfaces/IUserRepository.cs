using BlazorYoutubeDl.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorYoutubeDl.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task CreateUserAsync(User user);

        Task DeleteUserAsync(int id);

        Task<User> UpdateUserAsnyc(User user);
    }
}
