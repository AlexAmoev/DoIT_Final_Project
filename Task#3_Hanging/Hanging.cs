using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Hanging
{
    public static class Hanging
    {
        public static void Hangler(List<string>? words)
        {
            Console.WriteLine($"Attempts: 6\n");
            int attempts = 5;
            Random dom = new Random();
            int random = dom.Next(0, words.Count);
            string word = words[random];
            char[] wordLetters = word.ToCharArray();
            char[] FinalWordLetters = new char[wordLetters.Length];
            for (int i = 0; i < word.Length; i++)
            {
                FinalWordLetters[i] = '_';
                Console.Write("_");
            }
            Console.WriteLine();
            Console.WriteLine();
        start:
            string FinalWordLettersString = "";
            int index = -1;
            string? value = Console.ReadLine();
            string temp = CustomSplit.Split(value);
            value = temp;
            for (int i = 0; i < wordLetters.Length; i++)
            {
                index++;
                if (Convert.ToString(wordLetters[i]) == value)
                {
                    FinalWordLetters[index] = wordLetters[i];
                }
                FinalWordLettersString += FinalWordLetters[i];
            }
            string tempFinalWord = "";
            for (int i = 0; i < wordLetters.Length; i++)
            {
                tempFinalWord += wordLetters[i];
            }
            Console.WriteLine();
            Console.WriteLine($"Attempts: {attempts}\n");
            if (attempts != -1 && value.Length == 1)
            {
                for (int i = 0; i < FinalWordLetters.Length; i++)
                {
                    Console.Write(FinalWordLetters[i]);
                }
                if (tempFinalWord == FinalWordLettersString)
                {
                    Console.WriteLine();
                    Console.WriteLine("Congratulations you win !!!\n" +
                        $"{attempts} attempts left !");
                    goto end;
                }
            }
            else if (attempts != -1 && value.Length > 1)
            {
                if (tempFinalWord == value)
                {
                    Console.WriteLine("Congratulations you win !!!\n" +
                        $"{attempts} attempts left !");
                    goto end;
                }
                else if (attempts == -1)
                {
                    Console.WriteLine("The words don't match you lost !\n" +
                        $"{attempts} attempts left !");
                    goto end;
                }
                else
                {
                    Console.WriteLine("The words don't match \n!" +
                        $"{attempts} attempts left !");
                    goto start;
                }
            }
            Console.WriteLine();
            if (attempts == 0)
            {
                Console.WriteLine("You lose !\n" +
                    $"{attempts} attempts left !");
                goto end;
            }
            Console.WriteLine();
            Console.WriteLine();
            attempts--;
            goto start;
            end:
            Console.WriteLine();
        }
    }
}
