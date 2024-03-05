
namespace Task_2_Number_guesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("Select difficulty level:\n");
            Console.WriteLine("'1' - Easy: range 1-25\n");
            Console.WriteLine("'2' - Medium: range 1-50\n");
            Console.WriteLine("'3' - Hard: range 1-100\n");
            string? defficulty = Console.ReadLine();
            Console.WriteLine();
            string temp = CustomSplit.Split(defficulty);
            defficulty = temp;
            NumberGuesser.Guesser(defficulty);
        }
    }
}
