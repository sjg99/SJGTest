using Core.Order.App;
using Core.Order.App.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService service;

        public OrderController(OrderService service)
        {
            this.service = service;
        }

        [HttpGet("get-all")]
        public IEnumerable<OrderDTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet("get-order/{id}")]
        public OrderDTO GetOrder(Guid id)
        {
            return service.GetOrder(id);
        }

        [HttpPost("create-order")]
        public OrderDTO CreateOrder(CreateOrderDTO dto)
        {
            return service.CreateOrder(dto);
        }

        [HttpPost("edit-order")]
        public OrderDTO EditOrder(EditOrderDTO dto)
        {
            return service.EditOrder(dto);
        }

        [HttpDelete("delete-order/{id}")]
        public void DeleteOrder(Guid id)
        {
            service.DeleteOrder(id);
        }
    }
}
