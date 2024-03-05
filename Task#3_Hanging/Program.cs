namespace Task_3_Hanging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hanging.");
            Console.WriteLine("You have 6 attempts to guess the letters from the word.");
            Console.WriteLine("After that you have to enter the complete word, if the entered word matches the search word then you win, otherwise the game is over.");
            Console.WriteLine(" -If not one letter is correct, game is over.");
            Console.WriteLine(" -If you open and guess all the letters of a word while entering 6 letters, you win.\n");

            List<string> words = new List<string>
            {
                "apple", "banana", "orange", "grape", "kiwi",
                "strawberry", "pineapple", "blueberry", "peach", "watermelon"
            };

            Hanging.Hangler(words);
        }
    }
}
