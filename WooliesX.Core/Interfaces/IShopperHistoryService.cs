using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesX.Core.Resources;

namespace WooliesX.Core.Interfaces
{
    public interface IShopperHistoryService
    {
        Task<IEnumerable<ShopperHistoryResource>> GetShopperHistory(string sortOptions);
    }
}
