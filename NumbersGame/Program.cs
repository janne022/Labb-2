using System.Runtime.CompilerServices;
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
    // Generate a random number between 1 and 20
    Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök");
    Random random = new Random();
    int correctNumber = random.Next(1, 20);
    int timesGuessed = 0;
    do
    {
        Console.Write("Min gissning:");
        string userInput = Console.ReadLine() ?? "";
        int guess;
        // Get user input and check if it's a number
        bool success = int.TryParse(userInput, out guess);
        // Check if the guess is correct, too high, or too low
        if (success)
        {
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
        }
        else if (!success)
        {
            Console.WriteLine("Du måste ange ett nummer!");
        }
    } while (timesGuessed < 5);
    return false;
}