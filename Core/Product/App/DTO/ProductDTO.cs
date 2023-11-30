namespace Core.Product.App.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsSandwich { get; set; }
        public bool IsFries { get; set; }
        public bool IsDrink { get; set; }

        private ProductDTO(Guid id, string name, double price, bool isSandwich, bool isFries, bool isDrink)
        {
            Id = id;
            Name = name;
            Price = price;
            IsSandwich = isSandwich;
            IsFries = isFries;
            IsDrink = isDrink;
        }

        public static ProductDTO Of(Domain.Model.Product model)
        {
            return new ProductDTO(model.Id, model.Name, model.Price, model.IsSandwich, model.IsFries, model.IsDrink);
        }
    }
}
