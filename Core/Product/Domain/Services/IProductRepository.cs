using Utilities.Repository;

namespace Core.Product.Domain.Services
{
    public interface IProductRepository : ICrudRepository
    {
        public IList<Model.Product> GetSandwiches();
        public IList<Model.Product> GetExtras();
        public IList<Model.Product> GetProductsInList(IList<Guid> ids);
    }
}
