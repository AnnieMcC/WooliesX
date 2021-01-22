using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WooliesX.Core.Interfaces;
using WooliesX.Core.Resources;

namespace WooliesX.API.Controllers.v1
{
    [Route("ShopperHistory")]
    [ApiController]
    public class ShopperHistoryController : ControllerBase
    {
        private readonly IShopperHistoryService _shopperHistoryService;

        public ShopperHistoryController(IShopperHistoryService shopperHistoryService)
        {
            _shopperHistoryService = shopperHistoryService;
        }

        // GET: api/values
        [HttpGet(Name = nameof(GetAllShopperHistory))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<ShopperHistoryResource>>> GetAllShopperHistory([FromQuery] string sortOptions)
        {
            var shopperHistory = await _shopperHistoryService.GetShopperHistory(sortOptions);

            return Ok(shopperHistory);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
