namespace HW2ARRAYQ5;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        int[] longestSequence = FindLongestSequence(array);
        Console.WriteLine(string.Join(" ", longestSequence));
    }

    static int[] FindLongestSequence(int[] array)
    {
        int maxLength = 1;
        int currentLength = 1;
        int bestStartIndex = 0;
        int currentStartIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1])
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
                currentStartIndex = i;
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                bestStartIndex = currentStartIndex;
            }
        }

        int[] longestSequence = new int[maxLength];
        for (int i = 0; i < maxLength; i++)
        {
            longestSequence[i] = array[bestStartIndex + i];
        }
        return longestSequence;
    }
}