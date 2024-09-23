using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

internal class Program
{
    class UninterruptiblePowerSupply : ICloneable
    {
        public string? manufacturer { get; set; }
        public string? brand { get; set; }
        public int? capacity { get; set; }

        protected string[] possibleManufacturers = ["Apple", "Samsung", "Hp", "Dell", "Xiaomi", "Huawei", "Techno", "Google", "OnePlus", "Alcatel", "Asus", "Lenovo", "Vivo"];
        protected string[] possibleBrands = ["S1", "S2", "S3", "Redmi", "Nova", "Spark", "A60", "Go", "K15", "Galaxy", "15", "13", "B256"];

        public UninterruptiblePowerSupply()
        {
            this.manufacturer = possibleManufacturers[new Random().Next(0, possibleManufacturers.Length)];
            this.brand = possibleBrands[new Random().Next(0, possibleBrands.Length)];
            this.capacity = new Random().Next(0, 100_000);
        }

        public UninterruptiblePowerSupply(int seed)
        {
            this.manufacturer = possibleManufacturers[new Random(seed).Next(0, possibleManufacturers.Length)];
            this.brand = possibleBrands[new Random(seed).Next(0, possibleBrands.Length)];
            this.capacity = new Random(seed).Next(0, 100_000);
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"manufacturer: {manufacturer}, brand: {brand}, capacity: {capacity}");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    class PowerSupplies
    {
        private int _count;

        public Func<UninterruptiblePowerSupply, UninterruptiblePowerSupply, bool> CurrentMethod;

        public readonly Func<UninterruptiblePowerSupply, UninterruptiblePowerSupply, bool> byManufacturer =
    (x, y) => x.manufacturer.CompareTo(y.manufacturer) > 0;
        public readonly Func<UninterruptiblePowerSupply, UninterruptiblePowerSupply, bool> byBrand =
            (x, y) => x.brand.CompareTo(y.brand) > 0;
        public readonly Func<UninterruptiblePowerSupply, UninterruptiblePowerSupply, bool> byCapacity =
            (x, y) => x.capacity > (y.capacity);

        private PowerSupplies powerSupplies;

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
        public UninterruptiblePowerSupply[] supplies { get; set; }

        public PowerSupplies(int count)
        {
            this.Count = count;
            supplies = new UninterruptiblePowerSupply[count];
            for (int i = 0; i < count; i++)
            {
                supplies[i] = new UninterruptiblePowerSupply();
            }
        }

        public PowerSupplies(int count, int seed)
        {
            this.Count = count;
            supplies = new UninterruptiblePowerSupply[count];
            var random = new Random(seed);
            for (int i = 0; i < count; i++)
            {
                supplies[i] = new UninterruptiblePowerSupply(random.Next());
            }
        }

        public UninterruptiblePowerSupply this[int index]
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

        public void PrintArray()
        {
            for (int i = 0; i < Count; i++)
            {
                supplies[i].PrintInfo();
            }
        }

        public void SelectionSort(Func<UninterruptiblePowerSupply, UninterruptiblePowerSupply, bool> compare)
        {
            int length = Count;
            UninterruptiblePowerSupply temp;
            for (int j = 0; j < length - 1; j++)
            {
                int min = j;
                for (int i = j + 1; i < length; i++)
                {
                    if (compare(supplies[min], supplies[i]))
                    {
                        min = i;
                    }
                }
                temp = supplies[j];
                supplies[j] = supplies[min];
                supplies[min] = temp;
            }
        }

        public void BubbleSort(Func<UninterruptiblePowerSupply, UninterruptiblePowerSupply, bool> compare)
        {
            UninterruptiblePowerSupply temp;
            for (int j = 0; j < Count - 1; j++)
            {
                for (int i = 0; i < Count - 1; i++)
                {
                    if (compare(supplies[i], supplies[i + 1]))
                    {
                        temp = supplies[i + 1];
                        supplies[i + 1] = supplies[i];
                        supplies[i] = temp;
                    }
                }
            }
        }

        public void ShakerSort(Func<UninterruptiblePowerSupply, UninterruptiblePowerSupply, bool> compare)
        {
            bool isSwapped = true;
            int start = 0;
            int end = Count;

            while (isSwapped == true)
            {
                isSwapped = false;
                for (int i = start; i < end - 1; ++i)
                {
                    if (compare(supplies[i], supplies[i + 1]))
                    {
                        (supplies[i + 1], supplies[i]) = (supplies[i], supplies[i + 1]);
                        isSwapped = true;
                    }
                }
                if (isSwapped == false)
                    break;
                isSwapped = false;
                end = end - 1;
                for (int i = end - 1; i >= start; i--)
                {
                    if (compare(supplies[i], supplies[i + 1]))
                    {
                        (supplies[i + 1], supplies[i]) = (supplies[i], supplies[i + 1]);
                        isSwapped = true;
                    }
                }
                start = start + 1;
            }
        }
        
        public void ShellSort(Func<UninterruptiblePowerSupply, UninterruptiblePowerSupply, bool> compare)
        {
            for (int interval = Count / 2; interval > 0; interval /= 2)
            {
                for (int i = interval; i < Count; i++)
                {
                    var currentKey = supplies[i];
                    var k = i;
                    while (k >= interval && compare(supplies[k - interval], currentKey))
                    {
                        supplies[k] = supplies[k - interval];
                        k -= interval;
                    }
                    supplies[k] = currentKey;
                }
            }
        }

        public long InsertionSort(Func<UninterruptiblePowerSupply, UninterruptiblePowerSupply, bool> compare)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (compare(supplies[j - 1], supplies[j]))
                    {
                        (supplies[j], supplies[j - 1]) = (supplies[j - 1], supplies[j]);
                    }
                }
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public PowerSupplies Copy()
        {
            var copy = new PowerSupplies(Count);
            copy.CurrentMethod = CurrentMethod;
            for (int i = 0; i < Count; i++)
            {
                if (this[i] != null)
                    copy[i] = (UninterruptiblePowerSupply)this[i].Clone();
                else
                    copy[i] = null;
            }
            return copy;
        }
    }

    private static void Main(string[] args)
    {
        var count = 100;
        var original = new PowerSupplies(count);

        Console.WriteLine("Введите поле, по которому вы хотите сортировать массив. 1 - По изготовителю, 2 - По бренду, 3 - По вместимости.");
        switch (Console.ReadLine())
        {
            case "1":
                original.CurrentMethod = original.byManufacturer;
                break;
            case "2":
                original.CurrentMethod = original.byBrand;
                break;
            case "3":
                original.CurrentMethod = original.byCapacity;
                break;
            default:
                Console.WriteLine("Введите 1, 2 или 3");
                return;
        }
        original.PrintArray();


        Console.WriteLine($"Sorting {count} power supplies");
        var powerSupplies = original.Copy();
        var watch = Stopwatch.StartNew();
        powerSupplies.SelectionSort(powerSupplies.CurrentMethod);
        watch.Stop();
        Console.WriteLine($"Selection sort, time elapsed in ticks: {watch.ElapsedTicks}");
        powerSupplies.PrintArray();

        powerSupplies = original.Copy();
        watch = Stopwatch.StartNew();
        powerSupplies.BubbleSort(powerSupplies.CurrentMethod);
        watch.Stop();
        Console.WriteLine($"Bubble sort, time elapsed in ticks: {watch.ElapsedTicks}");
        powerSupplies.PrintArray();

        powerSupplies = original.Copy();
        watch = Stopwatch.StartNew();
        powerSupplies.ShakerSort(powerSupplies.CurrentMethod);
        watch.Stop();
        Console.WriteLine($"Shaker sort, time elapsed in ticks: {watch.ElapsedTicks}");
        powerSupplies.PrintArray();

        powerSupplies = original.Copy();
        watch = Stopwatch.StartNew();
        powerSupplies.ShellSort(powerSupplies.CurrentMethod);
        watch.Stop();
        Console.WriteLine($"Shell sort, time elapsed in ticks: {watch.ElapsedTicks}");
        powerSupplies.PrintArray();

        powerSupplies = original.Copy();
        watch = Stopwatch.StartNew();
        powerSupplies.InsertionSort(powerSupplies.CurrentMethod);
        watch.Stop();
        Console.WriteLine($"Insertion sort, time elapsed in ticks: {watch.ElapsedTicks}");
        powerSupplies.PrintArray();

    }
}