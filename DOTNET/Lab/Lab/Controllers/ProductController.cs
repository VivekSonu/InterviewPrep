using Lab.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductService product):ControllerBase
    {
        [HttpGet("product/")]
        public async Task<ActionResult> GetProduct()
        {
           return Ok( product.ProcessProduct());
        }
    }
}
