using Core.Product.App.DTO;
using Core.Product.Domain.Services;

namespace Core.Product.App
{
    public class ProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IList<ProductDTO> GetAll()
        {
            return repository.FindAll<Domain.Model.Product>().Select(ProductDTO.Of).ToList();
        }

        public IList<ProductDTO> GetSandwiches()
        {
            return repository.GetSandwiches().Select(ProductDTO.Of).ToList();
        }

        public IList<ProductDTO> GetExtras()
        {
            return repository.GetExtras().Select(ProductDTO.Of).ToList();
        }
    }
}
