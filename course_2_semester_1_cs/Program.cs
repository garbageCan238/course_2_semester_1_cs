internal class Program
{
    class UninterruptivlePowerSupply
    {
        public static string? manufacturer;
        public static string? brand;
        public static int? capacity;
    }

    private static void Main(string[] args)
    {
        UninterruptivlePowerSupply.manufacturer = "Samsung";
        UninterruptivlePowerSupply.brand = "Apple";
        UninterruptivlePowerSupply.capacity = 500;

        Console.WriteLine($"manufacturer: {UninterruptivlePowerSupply.manufacturer}, \nbrand: {UninterruptivlePowerSupply.brand}, \ncapacity: {UninterruptivlePowerSupply.capacity}");
    }
}