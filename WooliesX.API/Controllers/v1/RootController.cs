using Microsoft.AspNetCore.Mvc;

namespace WooliesX.API.Controllers.v1
{
    [Route("/")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null)
                , users = new
                {
                    href = Url.Link(nameof(UserController.GetAllUsers), null)
                }
                //, products = new 
                //{
                //    href = Url.Link(nameof(ProductController.GetProducts), null)
                //}
            };

            return Ok(response);
        }
    }
}
