using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ProductService : BaseRepository, IProductService
    {
        private readonly IConfigurationProvider _mappingConfiguration;

        public ProductService(AppDbContext context, IConfigurationProvider mappingConfiguration)
            : base(context)
        {
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<ProductResource> GetProductById(int productId)
        {
            var product = await _context.Product.SingleOrDefaultAsync(product => product.Id == productId);

            if (product == null)
            {
                return null;
            }

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<ProductResource>(product);
        }

        public async Task<IEnumerable<ProductResource>> GetProducts(string sortOptions)
        {
            var sortTerm = new SortTerm(sortOptions);
            sortTerm.GetSortTerm();

            var query = _context.Product.Sort(sortTerm);

            var products = query.ProjectTo<ProductResource>(_mappingConfiguration);

            return products;
        }
    }
}
