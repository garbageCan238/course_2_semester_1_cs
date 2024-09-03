internal class Program
{
    class UninterruptivlePowerSupply
    {
        public string? manufacturer;
        public string? brand;
        public decimal? capacity;
    }

    private static void Main(string[] args)
    {
        var powerSupply = new UninterruptivlePowerSupply();

        powerSupply.manufacturer = "Samsung";
        powerSupply.brand = "Apple";
        powerSupply.capacity = (decimal)235.124;

        Console.WriteLine($"manufacturer: {powerSupply.manufacturer}, brand: {powerSupply.brand}, capacity: {powerSupply.capacity}");
    }
}