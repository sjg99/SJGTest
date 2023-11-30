using Utilities.Domain;

namespace Core.Order.Domain.Model
{
    public class Detail : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        private Detail(Guid id, Guid productId, Guid orderId)
        {
            Id = id;
            ProductId = productId;
            OrderId = orderId;
        }

        internal void Initialize()
        {
            InitializeBase();
        }

        public static Detail Of(Guid id, Guid productId, Guid orderId)
        {
            return new Detail(id, productId, orderId);
        }

        protected Detail() { }
    }
}
