using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesX.Core.Models;

namespace WooliesX.Data.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
    }
}
