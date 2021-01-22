using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WooliesX.Core.Infrastructure;
using WooliesX.Core.Interfaces;
using WooliesX.Core.Models;
using WooliesX.Core.Resources;
using WooliesX.Data.Extensions;
using WooliesX.Data.Repository;

namespace WooliesX.Data.Services
{
    public class ShopperHistoryService : BaseRepository, IShopperHistoryService
    {
        private readonly IConfigurationProvider _mappingConfiguration;

        public ShopperHistoryService(AppDbContext context, IConfigurationProvider mappingConfiguration)
            : base(context)
        {
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<IEnumerable<ShopperHistoryResource>> GetShopperHistory(string sortOptions)
        {
            var sortTerm = new SortTerm(sortOptions);
            sortTerm.GetSortTerm();

            var query = _context.ShopperHistory
                .Include(sh => sh.Products);
//                .Sort(sortTerm);

            var shopperHistory = query.ProjectTo<ShopperHistoryResource>(_mappingConfiguration);

            return shopperHistory;
        }
    }
}
