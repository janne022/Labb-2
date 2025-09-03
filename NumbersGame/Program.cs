using System.Runtime.CompilerServices;

bool result = startGame();
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
    Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök");
    Random random = new Random();
    int correctNumber = random.Next(1, 20);
    Console.WriteLine(correctNumber);
    int timesGuessed = 0;
    do
    {
        Console.Write("Min gissning:");
        string userInput = Console.ReadLine() ?? "";
        int guess;
        bool success = int.TryParse(userInput, out guess);
        if (success && timesGuessed <= 5)
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