namespace HW1LQ1B;

class Program
{
    static void Main(string[] args)
    {
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Guess the number between 1 and 3:");

        while (true)
        {
            int guessedNumber = int.Parse(Console.ReadLine());
            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Your guess should be between 1 and 3.");
            }
            else if (guessedNumber < correctNumber)
            {
                Console.WriteLine("Your guess is too low.");
            }
            else if (guessedNumber > correctNumber)
            {
                Console.WriteLine("Your guess is too high.");
            }
            else
            {
                Console.WriteLine("You guessed the correct number!");
                break;
            }
        }
    }
}