namespace HW1CONSOLEQ2;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of centuries: ");
        int centuries = int.Parse(Console.ReadLine());

        decimal years = centuries * 100;
        decimal days = years * 365.2422m;
        decimal hours = days * 24;
        decimal minutes = hours * 60;
        decimal seconds = minutes * 60;
        decimal milliseconds = seconds * 1000;
        decimal microseconds = milliseconds * 1000;
        decimal nanoseconds = microseconds * 1000;

        // Output results
        Console.WriteLine(
            $"{centuries} centuries = {years} years = {Math.Floor(days)} days = {Math.Floor(hours)} hours = {Math.Floor(minutes)} minutes = {Math.Floor(seconds)} seconds = {Math.Floor(milliseconds)} milliseconds = {Math.Floor(microseconds)} microseconds = {Math.Floor(nanoseconds)} nanoseconds");
    }
}