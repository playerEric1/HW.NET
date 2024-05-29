namespace HW2STRQ3;

class Program
{
    static void Main(string[] args)
    {
        string text = "Hi,exe? ABBA! Hog fully a string: ExE. Bob";
        List<string> palindromes = ExtractPalindromes(text);

        palindromes = palindromes.Distinct().OrderBy(p => p).ToList();
        Console.WriteLine(string.Join(", ", palindromes));
    }

    static List<string> ExtractPalindromes(string text)
    {
        List<string> palindromes = new List<string>();
        string[] words = text.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (IsPalindrome(word))
            {
                palindromes.Add(word);
            }
        }
        return palindromes;
    }

    static bool IsPalindrome(string str)
    {
        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            if (char.ToLower(str[left]) != char.ToLower(str[right]))
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}