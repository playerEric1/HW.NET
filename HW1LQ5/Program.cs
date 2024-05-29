namespace HW1LQ5;

class Program
{
    static void Main(string[] args)
    {
        DateTime currentTime = DateTime.Now;

        switch (currentTime.Hour)
        {
            case >= 6 and < 12:
                Console.WriteLine("Good Morning");
                break;
            case >= 12 and < 18:
                Console.WriteLine("Good Afternoon");
                break;
            case >= 18 and < 21:
                Console.WriteLine("Good Evening");
                break;
            default:
                Console.WriteLine("Good Night");
                break;
        }
    }
}