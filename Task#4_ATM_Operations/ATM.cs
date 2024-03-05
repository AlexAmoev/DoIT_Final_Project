using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_4_ATM_Operations
{
    public class ATM
    {
        private const string _FileLocation = "../../../ATMhistory.json";
        private const string _CustomersFileLocation = "../../../Customers.json";
        private static List<Customer> CustomerData = new();
        private static List<ATM> ATMData = new();
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string OperationType { get; set; }
        public string OperationDate { get; set; }

        public string Comment { get; set; }
        public ATM()
        {
            
        }
        private static List<Customer> CustomerParse(string? input)
        {
            var result = JsonSerializer.Deserialize<List<Customer>>(input);
            return result;
        }
        private static List<ATM> ATMParse(string? input)
        {
            var result = JsonSerializer.Deserialize<List<ATM>>(input);
            return result;
        }
        private static string ToJson(ATM atm)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                WriteIndented = true,
            };
            string result = JsonSerializer.Serialize(atm, options);
            return result;
        }
        private static void SaveOperationHistory(ATM atm)
        {
            string? input = ToJson(atm);
            if (!input.StartsWith("{") || !input.EndsWith("}"))
            {
                Console.WriteLine("ERROR: invalid json format !");
            }
            string? actualData = File.ReadAllText(_FileLocation);
            actualData = actualData.TrimEnd(']');
            input = input.TrimEnd('}');
            File.WriteAllText(_FileLocation, $"{actualData} ,{input}  }}\n]");
        }
        public static void ViewBalance(Customer customer)
        {
            Console.WriteLine();
            Console.WriteLine($"Firstname: {customer.FirstName}\nLastname: " +
                $"{customer.LastName}\nBalance: {customer.Balance}");
            ATM atm = new ATM();
            atm.CustomerId = customer.IDNumber;
            atm.CustomerName = $"{customer.FirstName} {customer.LastName}";
            atm.OperationType = "Checked the balance";
            atm.OperationDate = DateTime.Now.ToString();
            atm.Comment = string.Empty;
            SaveOperationHistory(atm);
        }
        public static void RefillBalance(Customer customer)
        {
            Console.WriteLine();
            Console.Write("GEL: ");
            string? value = Console.ReadLine();
            Console.WriteLine();
            int sum = Split(value);
            customer.Balance += sum;
            Console.WriteLine($"Firstname: {customer.FirstName}\nLastname: " +
                $"{customer.LastName}\nBalance: {customer.Balance}");
            ATM atm = new ATM();
            atm.CustomerId = customer.IDNumber;
            atm.CustomerName = $"{customer.FirstName} {customer.LastName}";
            atm.OperationType = $"Refilled the balance with {sum} GEL";
            atm.OperationDate = DateTime.Now.ToString();
            atm.Comment = $"Current balance is {customer.Balance} GEL";
            CustomerData = CustomerParse(File.ReadAllText(_CustomersFileLocation));
            for (int i = 0; i < CustomerData.Count; i++)
            {
                if (CustomerData[i].IDNumber == customer.IDNumber)
                {
                    CustomerData[i].Balance = customer.Balance;
                }
            }
            customer.UpdateTheData(CustomerData);
            SaveOperationHistory(atm);
        }
        public static void WithdrawBalance(Customer customer)
        {
            start:
            Console.WriteLine();
            Console.Write("GEL: ");
            string? value = Console.ReadLine();
            Console.WriteLine();
            int sum = Split(value);
            if (customer.Balance < sum)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR: insufficient funds !!!\n");
                Console.WriteLine($"Your balance is: {customer.Balance}\n");
                Console.Write("Enter the amount you want to cash out: ");
                value = Console.ReadLine();
                Console.WriteLine();
                goto start;
            }
            else if (customer.Balance == 0)
            {
                IfBalanceZero:
                Console.WriteLine();
                Console.WriteLine("ERROR: insufficient funds !!!\n");
                Console.WriteLine($"Your balance is: {customer.Balance}\n");
                Console.WriteLine("Do you want to refill the balance ?\n");
                Console.WriteLine("YES(Y) / NO(N)\n");
                string? temp = Console.ReadLine();
                temp = temp.ToLower();
                if (temp == "y")
                {
                    RefillBalance(customer);
                }
                else if (temp == "n")
                {
                    return;
                }
                else
                {
                    goto IfBalanceZero;
                }
            }
            customer.Balance -= sum;
            Console.WriteLine();
            Console.WriteLine($"Firstname: {customer.FirstName}\nLastname: " +
                $"{customer.LastName}\nBalance: {customer.Balance}");
            ATM atm = new ATM();
            atm.CustomerId = customer.IDNumber;
            atm.CustomerName = $"{customer.FirstName} {customer.LastName}";
            atm.OperationType = $"Withdraw the balance with {sum} GEL";
            atm.OperationDate = DateTime.Now.ToString();
            atm.Comment = $"Current balance is {customer.Balance} GEL";
            CustomerData = CustomerParse(File.ReadAllText(_CustomersFileLocation));
            for (int i = 0; i < CustomerData.Count; i++)
            {
                if (CustomerData[i].IDNumber == customer.IDNumber)
                {
                    CustomerData[i].Balance = customer.Balance;
                }
            }
            customer.UpdateTheData(CustomerData);
            SaveOperationHistory(atm);
        }
        public static void OperationsHistory(Customer customer)
        {
            ATMData = ATMParse(File.ReadAllText(_FileLocation));
            List<ATM> SingleCustomerData = new List<ATM>();
            foreach (var item in ATMData)
            {
                if (item.CustomerId == customer.IDNumber)
                {
                    Console.WriteLine(item);
                    SingleCustomerData.Add(item); // თუ დამჭირდება ლისტის დაბრუნება
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
            temp = "";
            for (int i = 0; i < arrayChar.Length; i++)
            {
                temp += arrayChar[i];
            }
            int Num = Convert.ToInt32(temp);
            return Num;
        }
        public override string ToString()
        {
            return $"\nCustomer name: {this.CustomerName}\nOperation type: {this.OperationType}\nOperation date: {this.OperationDate}\nComment: {this.Comment}";
        }
    }
}
