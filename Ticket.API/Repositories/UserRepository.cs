using BlazorYoutubeDl.API.Context;
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
        private readonly YoutubeDlContext _context;

        public UserRepository(YoutubeDlContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var userList = await _context.Users
                .Include(v => v.Videos)
                .ToListAsync();

            return userList;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(x => x.Videos)
                .FirstAsync(x => x.Id == id);

            if (user is null)
                throw new HttpStatusException(StaticCast<int>(HttpStatusCode.NotFound), "Ein User mit dieser Id wurde nicht gefunden");

            return user;
        }

        public Task<User> UpdateUserAsnyc(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
