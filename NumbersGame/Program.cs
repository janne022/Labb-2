using System.Runtime.CompilerServices;
namespace NumbersGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Start the game
            bool result = startGame();
            // Print the result
            if (result)
            {
                Console.WriteLine("Wohoo! Du klarade det!");
            }
            else if (!result)
            {
                Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
            }

            bool startGame()
            {
                // Declare variables. numberRange uses LINQ to filter an array of ints to an array of strings
                string[] numberRange = Enumerable.Range(2, 59).Select(n => n.ToString()).ToArray();
                int timesGuessed = 0;
                var random = new Random();
                int correctNumber = random.Next(1, 21);
                // Generate a random number that user decides
                Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök");
                // Get roundAmount via slider. Could probably be improved by having its own method for ints
                int roundAmount = Menu.ReadSlider("Hur många tal vill du gissa på?", numberRange);
                do
                {
                    // Get int via user input
                    int guess = Menu.ReadInt("Skriv in numret du vill gissa på:");
                    // Check if the guess is correct, too high, or too low
                    if (guess.Equals(correctNumber))
                    {
                        return true;
                    }
                    else if (guess < correctNumber)
                    {
                        Console.WriteLine("Tyvärr, du gissade för lågt!");
                    }
                    else if (guess > correctNumber)
                    {
                        Console.WriteLine("Tyvärr, du gissade för högt!");
                    }
                    timesGuessed++;
                } while (timesGuessed < roundAmount);
                return false;
            }
        }
    }
}