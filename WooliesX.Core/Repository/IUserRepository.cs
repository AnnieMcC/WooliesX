using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesX.Core.Models;

namespace WooliesX.Core.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
    }
}
