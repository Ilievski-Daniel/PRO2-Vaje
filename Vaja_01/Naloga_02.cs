class Program
{
    static void Main()
    {
        Console.WriteLine("Temperature v °C in °K:");
        Console.WriteLine("-------------------------");
        Console.WriteLine("|   °C   |   °K   |");
        Console.WriteLine("-------------------------");

        for (int celsius = 0; celsius <= 100; celsius += 10)
        {
            double kelvin = CelsiusToKelvin(celsius);
            Console.WriteLine("|  {0,3}°C  |  {1,5}°K  |", celsius, kelvin);
        }

        Console.WriteLine("-------------------------");
    }

    static double CelsiusToKelvin(double celsius)
    {
        return celsius + 273.15;
    }
}
