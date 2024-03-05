using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Hanging
{
    public static class CustomSplit
    {
        public static string Split(string? value)
        {
        start:
            string temp = value.ToLower();
            value = temp;

            string[] arrayString = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            value = "";
            for (int i = 0; i < arrayString.Length; i++)
            {
                value += arrayString[i];
            }
            Console.WriteLine();
            if (IsAllLetters(value)) 
            {
                Console.WriteLine("ERROR: use only letters.\n");
                value = Console.ReadLine();
                Console.WriteLine();
                goto start;
            }
            return value;
        }
        static bool IsAllLetters(string str)
        {
            foreach (char c in str)
            {
                if (char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
