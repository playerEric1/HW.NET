namespace HW1LQ1;

class Program
{
    static void Main(string[] args)
    {
        int max = 500;
        bool overflowDetected = false;
        for (byte i = 0; i < max; i++)
        {
            if (i == 0 && overflowDetected)
            {
                Console.WriteLine("Warning: Overflow detected!");
                break;
            }
            if (i == 255) overflowDetected = true;
            Console.WriteLine(i);
        }
    }
}