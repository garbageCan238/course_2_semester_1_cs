﻿using System.Collections;
using System.Drawing;

internal class Program
{
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
            this.capacity = new Random().Next(0, 100_000);
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"UninterruptivlePowerSupply: manufacturer: {manufacturer}, brand: {brand}, capacity: {capacity}");
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

        public void SelectionSort(Func<UninterruptivlePowerSupply, UninterruptivlePowerSupply, bool> compare)
        {
            int length = Count;
            UninterruptivlePowerSupply temp;
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

        public void BubbleSort(Func<UninterruptivlePowerSupply, UninterruptivlePowerSupply, bool> compare)
        {
            UninterruptivlePowerSupply temp;
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

        public void ShakerSort(Func<UninterruptivlePowerSupply, UninterruptivlePowerSupply, bool> compare)
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
        
        public void ShellSort(Func<UninterruptivlePowerSupply, UninterruptivlePowerSupply, bool> compare)
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

    }

    private static void Main(string[] args)
    {
        var count = 10000;
        Console.WriteLine($"Sorting {count} power supplies by capasity...");

        var powerSupplies = new PowerSupplies(count);
        for (int i = 0; i < powerSupplies.Count; i++)
        {
            powerSupplies[i] = new UninterruptivlePowerSupply();
        }
        var watch = System.Diagnostics.Stopwatch.StartNew();
        powerSupplies.SelectionSort((x, y) => x.capacity > (y.capacity));
        watch.Stop();
        Console.WriteLine($"Selection sort, time elapsed in milisecond: {watch.ElapsedMilliseconds}");

        powerSupplies = new PowerSupplies(count);
        for (int i = 0; i < powerSupplies.Count; i++)
        {
            powerSupplies[i] = new UninterruptivlePowerSupply();
        }
        watch = System.Diagnostics.Stopwatch.StartNew();
        powerSupplies.BubbleSort((x, y) => x.capacity > (y.capacity));
        watch.Stop();
        Console.WriteLine($"Bubble sort, time elapsed in milisecond: {watch.ElapsedMilliseconds}");

        powerSupplies = new PowerSupplies(count);
        for (int i = 0; i < powerSupplies.Count; i++)
        {
            powerSupplies[i] = new UninterruptivlePowerSupply();
        }
        watch = System.Diagnostics.Stopwatch.StartNew();
        powerSupplies.ShakerSort((x, y) => x.capacity > (y.capacity));
        watch.Stop();
        Console.WriteLine($"Shaker sort, time elapsed in milisecond: {watch.ElapsedMilliseconds}");

        powerSupplies = new PowerSupplies(count);
        for (int i = 0; i < powerSupplies.Count; i++)
        {
            powerSupplies[i] = new UninterruptivlePowerSupply();
        }
        watch = System.Diagnostics.Stopwatch.StartNew();
        powerSupplies.ShellSort((x, y) => x.capacity > (y.capacity));
        watch.Stop();
        Console.WriteLine($"Shell sort, time elapsed in milisecond: {watch.ElapsedMilliseconds}");
    }
}