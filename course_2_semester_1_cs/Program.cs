using course_2_semester_1_cs;

var powerSupply = new UninterruptivlePowerSupply();

powerSupply.manufacturer = "Samsung";
powerSupply.brand = "Apple";
powerSupply.capacity = (decimal)235.124;

Console.WriteLine($"manufacturer: {powerSupply.manufacturer}, brand: {powerSupply.brand}, capacity: {powerSupply.capacity}");