using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterPageDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedProducts([FromQuery] PagingParams<ProductDto> pagingParams)
        {
            var result = await _productService.GetPagedProducts(pagingParams);
            return Ok(result);
        }

        [HttpGet("All")]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();
            return Ok(result);
        }
    }
}
