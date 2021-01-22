using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WooliesX.Core.Resources;
using WooliesX.Core.Interfaces;
using WooliesX.Core.Models;
using WooliesX.Data.Repository;

namespace WooliesX.Data.Services
{
    public class UserService : BaseRepository, IUserService
    {
        private readonly IConfigurationProvider _mappingConfiguration;

        public UserService(AppDbContext context, IConfigurationProvider mappingConfiguration)
            : base(context)
        {
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<IEnumerable<UserResource>> GetUsers()
        {
            var users = _context.User
                .ProjectTo<UserResource>(_mappingConfiguration);

            return await users.ToListAsync<UserResource>();
        }

        public async Task<UserResource> GetUserById(int id)
        {
            var user = await _context.User.SingleOrDefaultAsync(user => user.Id == id);

            if (user == null)
            {
                return null;
            }

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<UserResource>(user);
        }
    }
}
