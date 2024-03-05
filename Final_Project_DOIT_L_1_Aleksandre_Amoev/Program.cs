namespace Final_Project_DOIT_L_1_Aleksandre_Amoev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 2 numbers and select operation '+,-,*,/' .\n");
            while (true)
            {
                start:
                Console.Write("First number: ");
                string? temp1 = Console.ReadLine();
                Console.WriteLine();
                string[] arrayString1 = temp1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                temp1 = "";
                for (int i = 0; i < arrayString1.Length; i++) 
                {
                    temp1 += arrayString1[i];
                }
                char[] arrayChar1 = temp1.ToCharArray();
                foreach (char value in arrayChar1) 
                {
                    if (value != '0' && value != '1' && value != '2' && value != '3' && value != '4'
                        && value != '5' && value != '6' && value != '7' && value != '8' && value != '9')
                    {
                        Console.WriteLine("ERROR: use only numbers !\n");
                        goto start;
                    }
                }
                temp1 = "0";
                for (int i = 0; i < arrayChar1.Length; i++)
                {
                    temp1 += arrayChar1[i];
                }
                double Num1 = Convert.ToInt64(temp1);

                Console.Write("Second number: ");
                string? temp2 = Console.ReadLine();
                Console.WriteLine();
                string[] arrayString2 = temp2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                temp2 = "";
                for (int i = 0; i < arrayString2.Length; i++)
                {
                    temp2 += arrayString2[i];
                }
                char[] arrayChar2 = temp2.ToCharArray();
                foreach (char value in arrayChar2)
                {
                    if (value != '0' && value != '1' && value != '2' && value != '3' && value != '4'
                        && value != '5' && value != '6' && value != '7' && value != '8' && value != '9')
                    {
                        Console.WriteLine("ERROR: use only numbers !\n");
                        goto start;
                    }
                }
                temp2 = "0";
                for (int i = 0; i < arrayChar2.Length; i++)
                {
                    temp2 += arrayChar2[i];
                }
                double Num2 = Convert.ToInt64(temp2);

                Console.Write("Operation: ");
                string? operation = Console.ReadLine();
                Console.WriteLine();
                string[] arrayString3 = operation.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                operation = "";
                for (int i = 0; i < arrayString3.Length; i++)
                {
                    operation += arrayString3[i];
                }
                if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
                {
                    Console.WriteLine("ERROR: u can use only this operations '+,-,*,/' !\n");
                    goto start;
                }
                else
                {
                    switch (operation)
                    {
                        case "+":
                            Console.WriteLine($"{Num1} + {Num2} = {Num1 + Num2}\n");
                            break;
                        case "-":
                            Console.WriteLine($"{Num1} - {Num2} = {Num1 - Num2}\n");
                            break;
                        case "*":
                            Console.WriteLine($"{Num1} * {Num2} = {Num1 * Num2}\n");
                            break;
                        case "/":
                            if (Num1 == 0 || Num2 == 0)
                            {
                                Console.WriteLine("ERROR: You cannot divide by zero, use other numbers or operations !\n");
                                goto start;
                            }
                            else
                            {
                                Console.WriteLine($"{Num1} / {Num2} = {Num1 / Num2}\n");
                                break;
                            }
                        default:
                            Console.WriteLine("ERROR: Something went wrong try again !\n");
                            goto start;
                    }
                }
            }
        }
    }
}
