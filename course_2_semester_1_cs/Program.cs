internal class Program
{
    class UninterruptivlePowerSupply
    {
        public string? manufacturer;
        public string? brand;
        public int? capacity;

        protected string[] possibleManufacturers = ["Apple", "Samsung", "Hp", "Dell", "Xiaomi", "Huawei", "Techno", "Google", "OnePlus", "Alcatel", "Asus", "Lenovo", "Vivo"];
        protected string[] possibleBrands = ["S1", "S2", "S3", "Redmi", "Nova", "Spark", "A60", "Go", "K15", "Galaxy", "15", "13", "B256"];

        public UninterruptivlePowerSupply()
        {
            this.manufacturer = possibleManufacturers[new Random().Next(0, possibleManufacturers.Length)];
            this.brand = possibleBrands[new Random().Next(0, possibleBrands.Length)];
            this.capacity = new Random().Next(0, 1000);
        }
    }

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
        private UninterruptivlePowerSupply[] supplies;

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
        var powerSupplies = new PowerSupplies(10);
        for (int i = 0; i < powerSupplies.Count; i++)
        {
            powerSupplies[i] = new UninterruptivlePowerSupply();
            Console.WriteLine($"manufacturer: {powerSupplies[i].manufacturer}, brand: {powerSupplies[i].brand}, capacity: {powerSupplies[i].capacity}");
        }
    }
}