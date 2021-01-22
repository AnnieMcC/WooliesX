using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesX.Core.Resources;

namespace WooliesX.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResource>> GetUsers();

        Task<UserResource> GetUserById(int userId);
    }
}
