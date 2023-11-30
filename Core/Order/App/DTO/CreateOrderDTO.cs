using Core.Order.Domain.Model;
using Core.Product.Domain.Services;

namespace Core.Order.App.DTO
{
    public class CreateOrderDTO
    {
        public IList<Guid> ProductIds { get; set; }

        public Domain.Model.Order ToModel(IProductRepository productRepository)
        {
            var orderId = Guid.NewGuid();
            var details = new List<Detail>();
            foreach (var productId in ProductIds)
            {
                var product = productRepository.FindOrFail<Product.Domain.Model.Product>(productId);
                details.Add(Detail.Of(Guid.NewGuid(), product.Id, orderId));
            }
            return Domain.Model.Order.Of(orderId, details, productRepository);
        }
    }
}
