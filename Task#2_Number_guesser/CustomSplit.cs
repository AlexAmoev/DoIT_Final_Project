using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Number_guesser
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
            if (value != "1" && value != "2" && value != "3" && value != "easy" && value != "medium"
                    && value != "hard")
            {
                Console.WriteLine("ERROR: enter '1' to select Easy mode, enter '2' to select medium mode, enter '3' to select hard mode !\n" +
                    "Or you can write which mode you want to choose: 'easy', 'medium' or 'hard' !\n");
                value = Console.ReadLine();
                Console.WriteLine();
                goto start;
            }
            return value;
        }

    }
}