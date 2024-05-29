namespace HW2ARRAYQ4;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter array of integers:");
        int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        Console.WriteLine("Enter the number of rotations (k):");
        int k = int.Parse(Console.ReadLine());

        int n = array.Length;
        int[] sum = new int[n];

        for (int r = 1; r <= k; r++)
        {
            int[] rotatedArray = RotateArrayRight(array, r);
            for (int i = 0; i < n; i++)
            {
                sum[i] += rotatedArray[i];
            }
        }

        Console.WriteLine("Sum of arrays after each rotation:");
        foreach (int element in sum)
        {
            Console.Write(element + " ");
        }
    }
    static int[] RotateArrayRight(int[] array, int r)
    {
        int n = array.Length;
        int[] rotatedArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            int newPosition = (i + r) % n;
            rotatedArray[newPosition] = array[i];
        }
        return rotatedArray;
    }
}