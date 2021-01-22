using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WooliesX.Core.Interfaces;
using WooliesX.Core.Models;
using WooliesX.Core.Resources;

namespace WooliesX.API.Controllers.v1
{
    [Route("/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/values
        [HttpGet(Name = nameof(GetAllProducts))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<ProductResource>>> GetAllProducts([FromQuery]string sortOptions)
        {
            var products = await _productService.GetProducts(sortOptions);

            return Ok(products);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = nameof(GetProductById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ProductResource>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
