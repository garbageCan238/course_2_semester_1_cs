internal class Program
{
    class UninterruptivlePowerSupply
    {
        public string? manufacturer;
        public string? brand;
        public int? capacity;

        public UninterruptivlePowerSupply()
        {
        }

        public UninterruptivlePowerSupply(string? manufacturer, string? brand, int? capacity)
        {
            this.manufacturer = manufacturer;
            this.brand = brand;
            this.capacity = capacity;
        }
    }

    private static void Main(string[] args)
    {
        var first = new UninterruptivlePowerSupply();

        first.manufacturer = "Samsung";
        first.brand = "Apple";
        first.capacity = 500;

        Console.WriteLine($"first object: manufacturer: {first.manufacturer}, brand: {first.brand}, capacity: {first.capacity}");

        var second = new UninterruptivlePowerSupply("Dell", "Hp", 800);
        Console.WriteLine($"second object: manufacturer: {second.manufacturer}, brand: {second.brand}, capacity: {second.capacity}");
    }
}