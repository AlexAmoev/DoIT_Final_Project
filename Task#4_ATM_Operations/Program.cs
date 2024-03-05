namespace Task_4_ATM_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer NewCustomer = new Customer("Giorgi", "Gogidze", "12315178911");
            //var result = Customer.GetAllCustomers();
            //foreach (var customer in result) { Console.WriteLine(customer); }
            Console.WriteLine("ATM\n");
            Console.WriteLine("Loggin:\n");
            Console.Write("Id-number: ");
            string? IdNumber = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Pin-code: ");
            string? Pincode = Console.ReadLine();
            Console.WriteLine();
            var customer = Customer.ExistsCustomer(IdNumber, Pincode);
            ATM atm = new ATM();
            start:
            Console.WriteLine();
            Console.WriteLine("Select operation:\n");
            Console.WriteLine("1 - View balance\n2 - Refill ralance\n3 - Withdraw balance\n4 - View operations history\n");
            Console.WriteLine("Select by entering '1', '2', '3' or '4'.\n");
            string? operation = Console.ReadLine();
            Console.WriteLine();
            if (operation != "1" && operation != "2" && operation != "3" && operation != "4")
            {
                Console.WriteLine("\nERROR: invalid operation format !\n");
                goto start;
            }
            else if (operation == "1")
            {
                ATM.ViewBalance(customer);
                Console.WriteLine("\nWant to perform another operation?\n");
                Console.WriteLine("Y (YES) / N (NO)\n");
                string? exit = Console.ReadLine();
                exit = exit.ToLower();
                if (exit == "y" || exit == "yes")
                {
                    goto start;
                }
                else { return; }
            }
            else if (operation == "2")
            {
                ATM.RefillBalance(customer);
                Console.WriteLine("\nWant to perform another operation?\n");
                Console.WriteLine("Y (YES) / N (NO)\n");
                string? exit = Console.ReadLine();
                exit = exit.ToLower();
                if (exit == "y" || exit == "yes")
                {
                    goto start;
                }
                else { return; }
            }
            else if (operation == "3")
            {
                ATM.WithdrawBalance(customer);
                Console.WriteLine("\nWant to perform another operation?\n");
                Console.WriteLine("Y (YES) / N (NO)\n");
                string? exit = Console.ReadLine();
                exit = exit.ToLower();
                if (exit == "y" || exit == "yes")
                {
                    goto start;
                }
                else { return; }
            }
            else if (operation == "4")
            {
                ATM.OperationsHistory(customer);
                Console.WriteLine("\nWant to perform another operation?\n");
                Console.WriteLine("Y (YES) / N (NO)\n");
                string? exit = Console.ReadLine();
                exit = exit.ToLower();
                if (exit == "y" || exit == "yes")
                {
                    goto start;
                }
                else { return; }
            }

        }
    }
}
