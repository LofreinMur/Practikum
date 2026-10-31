
using System;

namespace Task26_Discounts
{
    interface IDiscountStrategy
    {
        decimal Apply(decimal price);
    }
    class NoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price)
        {
            return price;
        }
    }
    class VipDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price)
        {
            return price * 0.90m;
        }
    }
    class PromoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price)
        {
            return price * 0.80m;
        }
    }
    class PriceCalculator
    {
        private IDiscountStrategy discountStrategy;

        public PriceCalculator(IDiscountStrategy strategy)
        {
            discountStrategy = strategy;
        }
        public decimal Calculate(decimal price)
        {
            return discountStrategy.Apply(price);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal price = 1000m;
            PriceCalculator calculator1 =
                new PriceCalculator(new NoDiscount());
            PriceCalculator calculator2 =
                new PriceCalculator(new VipDiscount());
            PriceCalculator calculator3 =
                new PriceCalculator(new PromoDiscount());
            Console.WriteLine("Исходная цена: " + price + " руб.");
            Console.WriteLine(
                "Без скидки: " + calculator1.Calculate(price) + " руб.");
            Console.WriteLine(
                "VIP-скидка 10%: " + calculator2.Calculate(price) + " руб.")
            Console.WriteLine(
                "Промо-скидка 20%: " + calculator3.Calculate(price) + " руб.");
            Console.ReadKey();
        }
    }
}
