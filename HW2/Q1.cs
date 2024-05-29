namespace HW2;

class Q1
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int[] arr1 = new int[10];
        for (int i = 0; i < 10; i++)
        {
            arr1[i] = i;
        }

        int len = arr1.Length;
        int[] arr2 = new int[len];

        for (int i = 0; i < 10; i++)
        {
            arr2[i] = arr1[i];
            Console.WriteLine(arr1[i]);
            Console.WriteLine(arr2[i]);
        }
    }
}