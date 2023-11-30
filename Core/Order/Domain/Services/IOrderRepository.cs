using Core.Order.Domain.ReadModels;
using Utilities.Repository;

namespace Core.Order.Domain.Services
{
    public interface IOrderRepository : ICrudRepository
    {
        public IList<OrderReadModel> GetOrders();
        public OrderReadModel GetOrder(Guid id);
        public IList<Guid> GetSavedDetailsIds(Guid id);
    }
}
