using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Zadej sekvenci čísel oddělených čárkou:");
                string input = Console.ReadLine();
                string[] numbersStr = input.Split(',');
                int[] numbers = new int[numbersStr.Length];

                bool validInput = true;
                for (int i = 0; i < numbersStr.Length; i++)
                {
                    if (!int.TryParse(numbersStr[i], out numbers[i]))
                    {
                        Console.WriteLine("Neplatný vstup. Zadejte prosím pouze celá čísla oddělená čárkou.");
                        validInput = false;
                        break;
                    }
                }

                if (!validInput)
                    continue;
                int min = numbers.Min();
                int max = numbers.Max();
                int NejdelsiSekvence = CalculatenejvetsiSekvenci(numbers);

                Console.WriteLine($"Nejmenší číslo je {min}.");
                Console.WriteLine($"Největší číslo je {max}.");
                Console.WriteLine($"Délka nejdelšího vzestupného intervalu je {NejdelsiSekvence}.");
            }
        }


        static int CalculatenejvetsiSekvenci(int[] numbers)
        {
            int maxLength = 1;
            int currentLength = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    currentLength++;
                    maxLength = Math.Max(maxLength, currentLength);
                }
                else
                {
                    currentLength = 1;
                }
            }

            return maxLength;
        }
    }
}