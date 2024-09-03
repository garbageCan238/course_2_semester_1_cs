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

    private static void Main(string[] args)
    {
        var first = new UninterruptivlePowerSupply();

        first.manufacturer = "Samsung";
        first.brand = "Apple";
        first.capacity = (decimal)235.124;

        Console.WriteLine($"first object: manufacturer: {first.manufacturer}, brand: {first.brand}, capacity: {first.capacity}");

        var second = new UninterruptivlePowerSupply("Dell", "Hp", (decimal)6532.128);
        Console.WriteLine($"second object: manufacturer: {second.manufacturer}, brand: {second.brand}, capacity: {second.capacity}");
    }
}