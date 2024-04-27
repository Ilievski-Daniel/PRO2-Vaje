using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Vnesite celo število:");
        int number;
        if (int.TryParse(Console.ReadLine(), out number))
        {
            int sumOfDigits = SumOfDigits(number);
            if (sumOfDigits != -1)
            {
                Console.WriteLine("Seštevek števk v številu {0} je: {1}", number, sumOfDigits);
            }
            else
            {
                Console.WriteLine("Vneseno število je negativno.");
            }
        }
        else
        {
            Console.WriteLine("Napačen format vnosa. Prosimo, vnesite celo število.");
        }
        Console.ReadKey();
    }

    static int SumOfDigits(int number)
    {
        // Preveri, ali je število negativno
        if (number < 0)
        {
            return -1;
        }

        int sum = 0;
        // Iteriraj skozi vsako števko v številu
        while (number != 0)
        {
            sum += number % 10; // Dodaj zadnjo števko k vsoti
            number /= 10; // Odstrani zadnjo števko
        }
        return sum;
    }
}
