namespace HW2ARRAYQ3;

class Program
{
    static void Main(string[] args)
    {
        int[] primes = FindPrimesInRange(1, 100);
        foreach (int prime in primes)
        {
            Console.Write(prime + " ");
        }
    }

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        for (int num = startNum; num <= endNum; num++)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
        }

        return primes.ToArray();
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}