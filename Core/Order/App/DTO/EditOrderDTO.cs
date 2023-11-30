using Core.Order.Domain.Model;
using Core.Product.Domain.Services;

namespace Core.Order.App.DTO
{
    public class EditOrderDTO
    {
        public Guid Id { get; set; }
        public IList<Guid> ProductIds { get; set; }

        public Domain.Model.Order ToModel(IProductRepository productRepository)
        {
            var details = new List<Detail>();
            foreach (var productId in ProductIds)
            {
                details.Add(Detail.Of(Guid.NewGuid(), productId, Id));
            }
            return Domain.Model.Order.Of(Id, details, productRepository);
        }
    }
}
