using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_4_ATM_Operations
{
    public class Customer
    {
        private const string _FileLocation = "../../../Customers.json";
        private static List<Customer> _CustomersData = new();
        Random RandomBalance = new Random();
        public int ID { get; set; } // autoincrement DONE
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; } // unda iyos unikaluri DONE
        public int Password { get; set; } // უნდა იყოს უნიკალური, შედგებოდეს 4 ციფრისგან (ოთხნიშნა).
                                            // ავტომატურად უნდა მოხდეს მომხმარებლისთვის მინიჭება რეგისტრაციისას DONE
        public int Balance { get; set; }
        public Customer()
        {
            
        }
        public Customer(string firstName, string lastName, string id_number)
        {
            _CustomersData = Parse(File.ReadAllText(_FileLocation));
            //this.ID = _CustomersData.Max(x => x.ID) + 1;
            //FirstName = firstName;
            //LastName = lastName;
            //IDNumber = Split(id_number);
            //Password = GetPassword();
            //Balance = RandomBalance.Next(100, 100000);
            //SaveCustomer(this);
        }


        private static List<Customer> Parse(string? input)
        {
            var result = JsonSerializer.Deserialize<List<Customer>>(input);
            return result;
        }
        private string ToJson(Customer customer)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                WriteIndented = true,
            };
            string result = JsonSerializer.Serialize(customer, options);
            return result;
        }
        public void UpdateTheData(List<Customer> UpdateData)
        {
            string data = "";
            foreach (var customer in UpdateData)
            {
                data += $",\n{ToJson(customer)}\n";
            }
            data = data.Remove(0, 1);
            data = $"[\n{data}\n]";
            File.WriteAllText(_FileLocation, data);
        }
        private void SaveCustomer(Customer customer)
        {
            string? input = ToJson(customer);
            if (!input.StartsWith("{") || !input.EndsWith("}"))
            {
                Console.WriteLine("ERROR: invalid json format !");
            }
            string? actualData = File.ReadAllText(_FileLocation);
            actualData = actualData.TrimEnd(']');
            input = input.TrimEnd('}');
            File.WriteAllText(_FileLocation, $"{actualData} ,{input}  }}\n]");
        }
        public static List<Customer> GetAllCustomers()
        {
            return Parse(File.ReadAllText(_FileLocation));
        }
        public static Customer ExistsCustomer(string? IdNumber, string? password)
        {
            Customer temp = new Customer();
            var CustomersList = Parse(File.ReadAllText(_FileLocation));
            start:
            foreach (var Customer in CustomersList)
            {
                if (Customer.IDNumber == IdNumber && Customer.Password == Convert.ToInt32(password))
                {
                    return Customer;
                }
                else if (Customer.IDNumber == IdNumber && Customer.Password != Convert.ToInt32(password))
                {
                    Console.WriteLine("ERROR: incorrect password !!!\n");
                    Console.Write("Id-number: ");
                    IdNumber = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Pin-code: ");
                    password = Console.ReadLine();
                    Console.WriteLine();
                    goto start;
                }
            }
            Console.WriteLine("User with this ID-number was not found.\n");
            Console.WriteLine("Create an accaunt:\n");
            Customer NewCustomer = temp.CreateCustomer();

            return NewCustomer;
        }
        private Customer CreateCustomer()
        {
            _CustomersData = Parse(File.ReadAllText(_FileLocation));
            this.ID = _CustomersData.Max(x => x.ID) + 1;
            Console.Write("Fistname: ");
            string? firstName = Console.ReadLine();
            this.FirstName = firstName;
            Console.WriteLine();
            Console.Write("Lastname: ");
            string? lastName = Console.ReadLine();
            LastName = lastName;
            Console.WriteLine();
            Console.Write("ID-number: ");
            string? id_number = Console.ReadLine();
            IDNumber = Split(id_number);
            Console.WriteLine();
            Password = GetPassword();
            Balance = RandomBalance.Next(100, 100000);
            SaveCustomer(this);
            Console.WriteLine($"{this}\n\nRemember your password: {this.Password}\n");
            return this;
        }
        private int GetPassword()
        {
        start:
            Random random = new Random();
            int result = random.Next(1000, 9999);
            for (int i = 0; i < _CustomersData.Count; i++)
            {
                if (_CustomersData[i].Password == result)
                {
                    goto start;
                }
            }
            return result;
        }
        private string Split(string? temp)
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
                    Console.WriteLine("ERROR: incorrect format, use only numbers !\n");
                    Console.Write("Enter ID-number: ");
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
            if (temp.Length != 11)
            {
                Console.WriteLine("ERROR: incorrect format, ID must be 11 characters long !\n");
                Console.Write("Enter ID-number: ");
                temp = Console.ReadLine();
                Console.WriteLine();
                goto start;
            }

            for (int i = 0; i < _CustomersData.Count; i++)
            {
                if (_CustomersData[i].IDNumber == temp)
                {
                    Console.WriteLine("ERROR: users with this ID number already exist !\n");
                    Console.WriteLine("Enter ID-number: ");
                    temp = Console.ReadLine();
                    Console.WriteLine();
                    goto start;
                }
            }
            return temp;
        }
        public override string ToString()
        {
            return $"Firstname: {this.FirstName}\nLastname: {this.LastName}\nID-number: {this.IDNumber}\nPassword: {this.Password}\nBalance: {Balance}";
        }
    }
}
