namespace HW2Q2;

class Q2
{
    static void Main(string[] args)
    {
        List<String> currList = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
            foreach (var str in currList)
            {
                Console.WriteLine($"- {str}");
            }

            string input = Console.ReadLine().Trim();
            switch (input[0])
            {
                case '+':
                    string itemAdd = input.Substring(1).Trim();
                    Console.WriteLine(itemAdd);
                    if (!string.IsNullOrEmpty(itemAdd))
                    {
                        currList.Add(itemAdd);
                        Console.WriteLine($"Added: {itemAdd}");
                    }
                    else
                    {
                        Console.WriteLine("Error: No item provided.");
                    }

                    break;

                case '-':
                    string itemSub = input.Substring(1).Trim();
                    if (input.Length > 1 && input[1] == '-')
                    {
                        currList.Clear();
                        Console.WriteLine("List cleared.");
                        break;
                    }
                    else if (!string.IsNullOrEmpty(itemSub))
                    {
                        if (currList.Contains(itemSub))
                        {
                            currList.Remove(itemSub);
                            Console.WriteLine($"Removed: {itemSub}");
                        }
                        else
                        {
                            Console.WriteLine($"Error: {itemSub} not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: No item provided.");
                    }
                    break;

                default:
                    Console.WriteLine("Command not found.");
                    break;
            }
        }
    }
}