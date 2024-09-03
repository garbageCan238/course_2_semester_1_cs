using System.Collections.Generic;

internal class Program
{
    class UninterruptivlePowerSupply
    {
        public string? manufacturer;
        public string? brand;
        public decimal? capacity;

        public UninterruptivlePowerSupply()
        {
        }

        public UninterruptivlePowerSupply(string? manufacturer, string? brand, decimal? capacity)
        {
            this.manufacturer = manufacturer;
            this.brand = brand;
            this.capacity = capacity;
        }
        
        public virtual void PrintInfo()
        {
            Console.WriteLine($"UninterruptivlePowerSupply: manufacturer: {manufacturer}, brand: {brand}, capacity: {capacity}");
        }
    }

    class PowerSupplyForSale : UninterruptivlePowerSupply
    {
        public Decimal? price;

        public PowerSupplyForSale(string? manufacturer, string? brand, decimal? capacity, decimal? price) : base(manufacturer, brand, capacity)
        {
            this.price = price;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"PowerSupplyForSale: manufacturer: {manufacturer}, brand: {brand}, capacity: {capacity}, price: {price}");
        }
    }

    private static void Main(string[] args)
    {
        var first = new UninterruptivlePowerSupply("Samsung", "Apple", 500);
        first.PrintInfo();

        var second = new PowerSupplyForSale("Dell", "Hp", 300, 5425);
        second.PrintInfo();
    }
}