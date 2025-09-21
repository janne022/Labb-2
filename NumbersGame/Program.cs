using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
namespace NumbersGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool isPlayAgain = true;
            while (isPlayAgain)
            {
                // Start the game, get bool for if user won or not
                bool isUserWinner = StartGame();

                // Print the result
                if (isUserWinner)
                {
                    Console.WriteLine("Wohoo! Du klarade det!");
                }
                else if (!isUserWinner)
                {
                    Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                }
                Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                Console.ReadLine();
                // Check if user wants to play again. For future refrence the help method could be changed to return a bool instead for this enum
                bool playAgain = Menu.ReadBoolOption("Vill du köra igen?", ["Ja", "Nej"]);
                isPlayAgain = playAgain;
            }
        }

        private static bool StartGame()
        {
            // Declare variables. numberRange uses LINQ to filter an array of ints to an array of strings
            string[] numberRange = Enumerable.Range(2, 99).Select(n => n.ToString()).ToArray();
            string[] responsesHigh = ["Tyvärr, du gissade för högt!", "Haha! Det var för högt!", "Bra gissat, men det var för högt"];
            string[] responsesLow = ["Tyvärr, du gissade för lågt!", "Haha! Det var för lågt!", "Bra gissat, men det var för lågt"];
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
                    // If guess it within 2 of correct number it prints "Det bränns!", else random response
                    if (correctNumber - guess < 2)
                    {
                        Console.WriteLine("Det bränns!");
                    }
                    else
                    {
                        Console.WriteLine(responsesLow[random.Next(0, responsesLow.Length)]);
                    }
                }
                else if (guess > correctNumber)
                {
                    // If guess it within 2 of correct number it prints "Det bränns!", else random response
                    if (guess - correctNumber < 2)
                    {
                        Console.WriteLine("Det bränns!");
                    }
                    else
                    {
                        Console.WriteLine(responsesHigh[random.Next(0, responsesHigh.Length)]);
                    }
                }
                timesGuessed++;
                Thread.Sleep(2000);
            } while (timesGuessed < 5);
            return false;
        }
    }
}