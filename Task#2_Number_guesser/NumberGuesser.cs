using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Number_guesser
{
    public static class NumberGuesser
    {
        public static void Guesser(string defficulty)
        {
            int attempts = 9;
            Random random = new Random();
            int easy = random.Next(1, 25);
            int medium = random.Next(1, 50);
            int hard = random.Next(1, 100);
        start:
            Console.Write("Enter number: ");
            string? temp = Console.ReadLine();
            Console.WriteLine();

            int num = Split(temp);
            if (defficulty == "1" || defficulty == "easy")
            {
                if (num == easy)
                {
                    Console.WriteLine("Congratulations you win !!!\n" +
                        $"{attempts} attempts left !\n");
                }
                else
                {
                    if (attempts == 0)
                    {
                        Console.WriteLine("You lose 0 attempts left !!!\n");
                    }
                    else if (num > easy)
                    {
                        Console.WriteLine($"Your {num} is higher than expected, {attempts} attempts left.\n");
                        attempts--;
                        goto start;
                    }
                    else if (num < easy)
                    {
                        Console.WriteLine($"Your {num} is below than expected, {attempts} attempts left.\n");
                        attempts--;
                        goto start;
                    }
                }
            }
            if (defficulty == "2" || defficulty == "medium")
            {
                if (num == medium)
                {
                    Console.WriteLine("Congratulations you win !!!\n" +
                        $"{attempts} attempts left !\n");
                }
                else
                {
                    if (attempts == 0)
                    {
                        Console.WriteLine("You lose 0 attempts left !!!\n");
                    }
                    else if (num > medium)
                    {
                        Console.WriteLine($"Your {num} is higher than expected, {attempts} attempts left.\n");
                        attempts--;
                        goto start;
                    }
                    else if (num < medium)
                    {
                        Console.WriteLine($"Your {num} is below than expected, {attempts} attempts left.\n");
                        attempts--;
                        goto start;
                    }
                }
            }
            if (defficulty == "3" || defficulty == "hard")
            {
                if (num == hard)
                {
                    Console.WriteLine("Congratulations you win !!!\n" +
                        $"{attempts} attempts left !\n");
                }
                else
                {
                    if (attempts == 0)
                    {
                        Console.WriteLine("You lose 0 attempts left !!!\n");
                    }
                    else if (num > hard)
                    {
                        Console.WriteLine($"Your {num} is higher than expected, {attempts} attempts left.\n");
                        attempts--;
                        goto start;
                    }
                    else if (num < hard)
                    {
                        Console.WriteLine($"Your {num} is below than expected, {attempts} attempts left.\n");
                        attempts--;
                        goto start;
                    }
                }
            }
        }
        private static int Split(string? temp)
        {
            start:
            string[] arrayString = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            temp = "";
            for (int i = 0; i < arrayString.Length; i++)
            {
                temp += arrayString[i];
            }
            char[] arrayChar = temp.ToCharArray();
            foreach (char value in arrayChar)
            {
                if (value != '0' && value != '1' && value != '2' && value != '3' && value != '4'
                    && value != '5' && value != '6' && value != '7' && value != '8' && value != '9')
                {
                    Console.WriteLine("ERROR: use only numbers !\n");
                    Console.Write("Enter number: ");
                    temp = Console.ReadLine();
                    Console.WriteLine();
                    goto start;
                }
            }
            temp = "0";
            for (int i = 0; i < arrayChar.Length; i++)
            {
                temp += arrayChar[i];
            }
            int Num = Convert.ToInt32(temp);
            return Num;
        }
    }
}
