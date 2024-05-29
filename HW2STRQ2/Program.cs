namespace HW2STRQ2;

class Program
{
    static void Main(string[] args)
    {
        string input = "C# is not C++, and PHP is not Delphi!";
        char[] separators = { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };

        // Split the input and keep separators
        List<string> words = new List<string>(input.Split(separators, StringSplitOptions.RemoveEmptyEntries));
        List<string> separatorsList = new List<string>();
        foreach (char c in input)
        {
            if (separators.Contains(c))
            {
                separatorsList.Add(c.ToString());
            }
        }

        // Rebuild the sentence
        words.Reverse();
        int wordIndex = 0, separatorIndex = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (separators.Contains(input[i]))
            {
                Console.Write(separatorsList[separatorIndex++]);
            }
            else if (wordIndex < words.Count && (i == 0 || separators.Contains(input[i-1])))
            {
                Console.Write(words[wordIndex++]);
            }
        }
    }
}