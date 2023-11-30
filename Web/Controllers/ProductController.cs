using Core.Product.App;
using Core.Product.App.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService service;

        public ProductController(ProductService service)
        {
            this.service = service;
        }

        [HttpGet("get-all")]
        public IEnumerable<ProductDTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet("get-sandwiches")]
        public IEnumerable<ProductDTO> GetSandwiches()
        {
            return service.GetSandwiches();
        }

        [HttpGet("get-extras")]
        public IEnumerable<ProductDTO> GetExtras()
        {
            return service.GetExtras();
        }
    }
}
