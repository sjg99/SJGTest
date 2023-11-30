using Core.Product.Domain.Model;
using Core.Product.Domain.Services;
using Infrastructure.EntityFramework;
using Utilities.Repository;

namespace Infrastructure.Repositories
{
    public class ProductRepository : EntityFrameworkRepository<SJGTestContext>, IProductRepository
    {
        public ProductRepository(SJGTestContext dbContext) : base(dbContext)
        {
        }

        public IList<Product> GetExtras()
        {
            return dbContext.Products.Where(x => !x.IsSandwich).ToList();
        }

        public IList<Product> GetProductsInList(IList<Guid> ids)
        {
            return dbContext.Products.Where(x => ids.Contains(x.Id)).ToList();
        }

        public IList<Product> GetSandwiches()
        {
            return dbContext.Products.Where(x => x.IsSandwich).ToList();
        }
    }
}
