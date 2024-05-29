namespace HW2ARRAYQ7;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 2, 1, 1, 2, 3, 3, 2, 3, 1 };
        int result = FindMostFrequent(array);
        Console.WriteLine("Most frequent number is: " + result);
    }

    static int FindMostFrequent(int[] array)
    {
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        foreach (int num in array)
        {
            frequencyMap.TryGetValue(num, out int count);
            frequencyMap[num] = count + 1;
        }

        int maxFrequency = frequencyMap.Max(pair => pair.Value);
        List<int> mostFrequentNumbers = frequencyMap.Where(pair => pair.Value == maxFrequency)
            .Select(pair => pair.Key)
            .ToList();

        return mostFrequentNumbers.First();
    }
}