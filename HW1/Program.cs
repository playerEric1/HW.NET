namespace HW1;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        Console.Write("Enter your favorite color: ");
        string favoriteColor = Console.ReadLine();

        Console.Write("Enter your street address number: ");
        string streetAddressNumber = Console.ReadLine();

        Console.WriteLine("Your hacker name is: " + favoriteColor + streetAddressNumber);
    }
}