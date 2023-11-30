using Core.Order.Domain.ReadModels;

namespace Core.Order.App.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime Created { get; set; }
        public IList<DetailDTO> Details { get; set; }

        private OrderDTO(Guid id, double totalAmount, DateTime created, IList<DetailDTO> details)
        {
            Id = id;
            TotalAmount = totalAmount;
            Created = created;
            Details = details;
        }

        public static OrderDTO Of(OrderReadModel model)
        {
            return new OrderDTO(model.Id, model.TotalAmount, model.Created, model.Details.Select(DetailDTO.Of).ToList());
        }
    }
}
