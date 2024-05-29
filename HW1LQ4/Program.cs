namespace HW1LQ3;

class Program
{
    static void Main(string[] args)
    {
        DateTime birthDate = new DateTime(1980, 1, 1);

        // Calculate how many days old
        TimeSpan age = DateTime.Today - birthDate;
        int daysOld = (int)age.TotalDays;
        Console.WriteLine($"The person is {daysOld} days old.");

        // Calculate the next 10000 day anniversary
        int daysToNextAnniversary = 10000 - (daysOld % 10000);
        DateTime nextAnniversary = DateTime.Today.AddDays(daysToNextAnniversary);
        Console.WriteLine($"The next 10000 day anniversary is on: {nextAnniversary:d}");
    }
}