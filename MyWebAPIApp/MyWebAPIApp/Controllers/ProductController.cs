using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Interface;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll(string? search, double? from, double? to, string? sort, int page = 1)
        {
            try
            {
                var result = _productRepository.GetAllProducts(search, from, to, sort, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
