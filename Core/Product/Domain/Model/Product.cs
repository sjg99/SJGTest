using Utilities.Domain;

namespace Core.Product.Domain.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsSandwich { get; set; }
        public bool IsFries { get; set; }
        public bool IsDrink { get; set; }
    }
}
