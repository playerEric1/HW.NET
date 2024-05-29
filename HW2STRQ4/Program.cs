namespace HW2STRQ4;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter URL:");
        string inputUrl = Console.ReadLine();
        string pattern = @"^(?<protocol>\w+):\/\/?(?<server>[^\/]+)(?:\/(?<resource>.*))?$";

        Match match = Regex.Match(inputUrl, pattern);

        string protocol = match.Groups["protocol"].Value;
        string server = match.Groups["server"].Value;
        string resource = match.Groups["resource"].Value;

        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
    }
}