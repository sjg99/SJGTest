using Core.Order.App.DTO;
using Core.Order.Domain.Model;
using Core.Order.Domain.Services;
using Core.Product.Domain.Services;

namespace Core.Order.App
{
    public class OrderService
    {
        private readonly IOrderRepository repository;
        private readonly IProductRepository productRepository;

        public OrderService(IOrderRepository repository, IProductRepository productRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
        }

        public IList<OrderDTO> GetAll()
        {
            return repository.GetOrders().Select(OrderDTO.Of).ToList();
        }

        public OrderDTO GetOrder(Guid id)
        {
            return OrderDTO.Of(repository.GetOrder(id));
        }

        public OrderDTO CreateOrder(CreateOrderDTO dto)
        {
            var model = dto.ToModel(productRepository);
            model.Initialize();
            repository.Save(model);
            foreach (var detail in model.Details)
            {
                detail.Initialize();
                repository.Save(detail);
            }
            repository.CommitChanges();
            return OrderDTO.Of(repository.GetOrder(model.Id));
        }

        public OrderDTO EditOrder(EditOrderDTO dto)
        {
            var changed = dto.ToModel(productRepository);
            var existent = repository.FindOrFail<Domain.Model.Order>(changed.Id);
            existent.UpdateFrom(changed);
            var existentDetailsIds = repository.GetSavedDetailsIds(changed.Id);
            foreach (var detailId in existentDetailsIds)
            {
                repository.Delete<Detail>(detailId);
            }
            foreach (var detail in changed.Details)
            {
                detail.Initialize();
                repository.Save(detail);
            }
            repository.CommitChanges();
            return OrderDTO.Of(repository.GetOrder(changed.Id));
        }

        public void DeleteOrder(Guid id)
        {
            var existent = repository.FindOrFail<Domain.Model.Order>(id);
            var existentDetailsIds = repository.GetSavedDetailsIds(existent.Id);
            foreach (var detailId in existentDetailsIds)
            {
                repository.Delete<Detail>(detailId);
            }
            repository.Delete<Domain.Model.Order>(existent.Id);
            repository.CommitChanges();
        }
    }
}
