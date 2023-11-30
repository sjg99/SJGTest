using Core.Product.Domain.Services;
using Utilities;
using Utilities.Domain;

namespace Core.Order.Domain.Model
{
    public class Order : BaseEntity
    {
        public double TotalAmount { get; set; }
        public IList<Detail> Details { get; set; }

        private Order(Guid id, double totalAmount, IList<Detail> details)
        {
            Id = id;
            TotalAmount = totalAmount;
            Details = details;
        }

        internal void Initialize()
        {
            InitializeBase();
        }

        internal void UpdateFrom(Order order)
        {
            TotalAmount = order.TotalAmount;
        }

        public static Order Of(Guid id, IList<Detail> details, IProductRepository productRepository)
        {
            var totalAmount = ValidateBusinessRules(details, productRepository);
            return new Order(id, totalAmount, details);
        }

        private static double ValidateBusinessRules(IList<Detail> details, IProductRepository productRepository)
        {
            Guards.Require(details.Count > 0, "Min 1 item per order");
            Guards.Require(details.Count <= 3, "Max 3 items per order");
            var anyDuplicate = details.GroupBy(x => x.ProductId).Any(y => y.Count() > 1);
            Guards.Require(!anyDuplicate, "There are repeated items in the order");
            var productIds = details.GroupBy(x => x.ProductId).Select(x => x.First().ProductId).ToList();
            var products = productRepository.GetProductsInList(productIds);
            var duplicateSandwich = products.Where(x => x.IsSandwich).Count() > 1;
            Guards.Require(!duplicateSandwich, "There are multiple sandwiches in the order");
            var amount = Is20Discount(products);
            if (amount.HasValue)
                return amount.Value;
            else
            {
                amount = Is15Discount(products);
                if (amount.HasValue)
                    return amount.Value;
                else
                {
                    amount = Is10Discount(products);
                    if (amount.HasValue)
                        return amount.Value;
                    else
                        return NoDiscount(products);
                }
            }
        }

        private static double? Is20Discount(IList<Product.Domain.Model.Product> products)
        {
            double? amount = null;
            if (products.Count == 3)
            {
                var hasSandwich = products.FirstOrDefault(x => x.IsSandwich) != null;
                var hasFries = products.FirstOrDefault(x => x.IsFries) != null;
                var hasDrink = products.FirstOrDefault(x => x.IsDrink) != null;
                if (hasSandwich && hasFries && hasDrink)
                {
                    var totalPrice = products.Sum(x => x.Price);
                    amount = totalPrice - (totalPrice * 0.2);
                }
            }
            return amount;
        }
        private static double? Is15Discount(IList<Product.Domain.Model.Product> products)
        {
            double? amount = null;
            if (products.Count == 2)
            {
                var hasSandwich = products.FirstOrDefault(x => x.IsSandwich) != null;
                var hasDrink = products.FirstOrDefault(x => x.IsDrink) != null;
                if (hasSandwich && hasDrink)
                {
                    var totalPrice = products.Sum(x => x.Price);
                    amount = totalPrice - (totalPrice * 0.15);
                }
            }
            return amount;
        }
        private static double? Is10Discount(IList<Product.Domain.Model.Product> products)
        {
            double? amount = null;
            if (products.Count == 2)
            {
                var hasSandwich = products.FirstOrDefault(x => x.IsSandwich) != null;
                var hasFries = products.FirstOrDefault(x => x.IsFries) != null;
                if (hasSandwich && hasFries)
                {
                    var totalPrice = products.Sum(x => x.Price);
                    amount = totalPrice - (totalPrice * 0.1);
                }
            }
            return amount;
        }
        private static double NoDiscount(IList<Product.Domain.Model.Product> products)
        {
            double amount = 0;
            amount = products.Sum(x => x.Price);
            return amount;
        }

        protected Order() { }
    }
}
