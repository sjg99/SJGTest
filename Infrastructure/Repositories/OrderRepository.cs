using Core.Order.Domain.ReadModels;
using Core.Order.Domain.Services;
using Infrastructure.EntityFramework;
using Utilities.Exceptions;
using Utilities.Repository;

namespace Infrastructure.Repositories
{
    public class OrderRepository : EntityFrameworkRepository<SJGTestContext>, IOrderRepository
    {
        public OrderRepository(SJGTestContext dbContext) : base(dbContext)
        {
        }

        public OrderReadModel GetOrder(Guid id)
        {
            var query = from order in dbContext.Orders
                        where order.Id == id
                        select new OrderReadModel
                        {
                            Id = order.Id,
                            TotalAmount = order.TotalAmount,
                            Created = order.Created,
                            Details = (from detail in dbContext.Details
                                       join product in dbContext.Products on detail.ProductId equals product.Id
                                       where detail.OrderId == order.Id
                                       select new DetailReadModel
                                       {
                                           Id = detail.Id,
                                           ProductId = product.Id,
                                           ProductName = product.Name,
                                           ProductPrice = product.Price
                                       }).ToList()
                        };
            var result = query.FirstOrDefault();
            return result ?? throw new CustomException("Order not found");
        }

        public IList<OrderReadModel> GetOrders()
        {
            var query = from order in dbContext.Orders
                        select new OrderReadModel
                        {
                            Id = order.Id,
                            TotalAmount = order.TotalAmount,
                            Created = order.Created,
                            Details = (from detail in dbContext.Details
                                       join product in dbContext.Products on detail.ProductId equals product.Id
                                       where detail.OrderId == order.Id
                                       select new DetailReadModel
                                       {
                                           Id = detail.Id,
                                           ProductId = product.Id,
                                           ProductName = product.Name,
                                           ProductPrice = product.Price
                                       }).ToList()
                        };
            return query.ToList();
        }

        public IList<Guid> GetSavedDetailsIds(Guid id)
        {
            return dbContext.Details.Where(x => x.OrderId == id).Select(x => x.Id).ToList();
        }
    }
}
