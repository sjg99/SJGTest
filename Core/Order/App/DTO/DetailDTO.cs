using Core.Order.Domain.ReadModels;

namespace Core.Order.App.DTO
{
    public class DetailDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        private DetailDTO(Guid id, Guid productId, string productName, double productPrice)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
        }

        public static DetailDTO Of(DetailReadModel model)
        {
            return new DetailDTO(model.Id, model.ProductId, model.ProductName, model.ProductPrice);
        }
    }
}
