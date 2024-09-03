using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using static System.Collections.Specialized.BitVector32;

internal class Program
{
    [Serializable]
    class UninterruptivlePowerSupply
    {
        public string? manufacturer { get; set; }
        public string? brand { get; set; }
        public int? capacity { get; set; }

        protected string[] possibleManufacturers = ["Apple", "Samsung", "Hp", "Dell", "Xiaomi", "Huawei", "Techno", "Google", "OnePlus", "Alcatel", "Asus", "Lenovo", "Vivo"];
        protected string[] possibleBrands = ["S1", "S2", "S3", "Redmi", "Nova", "Spark", "A60", "Go", "K15", "Galaxy", "15", "13", "B256"];

        public UninterruptivlePowerSupply()
        {
            this.manufacturer = possibleManufacturers[new Random().Next(0, possibleManufacturers.Length)];
            this.brand = possibleBrands[new Random().Next(0, possibleBrands.Length)];
            this.capacity = new Random().Next(0, 1000);
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"UninterruptivlePowerSupply: manufacturer: {manufacturer}, brand: {brand}, capacity: {capacity}");
        }

    }

    [Serializable]
    class PowerSupplies
    {
        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            private set
            {
                _count = value;
            }
        }
        public UninterruptivlePowerSupply[] supplies { get; set; }

        public PowerSupplies(int count)
        {
            this.Count = count;
            supplies = new UninterruptivlePowerSupply[count];
        }

        public UninterruptivlePowerSupply this[int index]
        {
            get
            {
                return supplies[index];
            }
            set
            {
                supplies[index] = value;
            }
        }
    }

    private static void Main(string[] args)
    {
        var singlePowerSupply = new UninterruptivlePowerSupply();

        var powerSupplies = new PowerSupplies(5);
        for (int i = 0; i < powerSupplies.Count; i++)
        {
            powerSupplies[i] = new UninterruptivlePowerSupply();
        }

        Console.WriteLine("Single: ");
        singlePowerSupply.PrintInfo();
        Console.WriteLine("Container: ");
        for (int i = 0; i < powerSupplies.Count; i++)
        {
            powerSupplies[i].PrintInfo();
        }

        using (var fs = new FileStream("single_power_supply.txt", FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(fs, singlePowerSupply);
        }

        using (var fs = new FileStream("power_supplies.txt", FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(fs, powerSupplies);
        }

        UninterruptivlePowerSupply? deserializedPowerSupply = null;
        PowerSupplies? deserializedPowerSupplies = null;

        using (var jsonFileReader = File.OpenText("single_power_supply.txt"))
        {
            deserializedPowerSupply = JsonSerializer.Deserialize<UninterruptivlePowerSupply> (jsonFileReader.ReadToEnd(),
            new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        using (var jsonFileReader = File.OpenText("power_supplies.txt"))
        {
            deserializedPowerSupplies = JsonSerializer.Deserialize<PowerSupplies>(jsonFileReader.ReadToEnd(),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        Console.WriteLine("\nDeserialized single: ");
        deserializedPowerSupply.PrintInfo();
        Console.WriteLine("Deserialized container: ");
        for (int i = 0; i < deserializedPowerSupplies.Count; i++)
        {
            deserializedPowerSupplies[i].PrintInfo();
        }

    }
}