namespace Core.Order.Domain.ReadModels
{
    public class OrderReadModel
    {
        public Guid Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime Created { get; set; }
        public IList<DetailReadModel> Details { get; set; }
    }
}
