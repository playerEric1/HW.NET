﻿namespace HW1LQ2;

class Program
{
    static void Main(string[] args)
    {
        int rows = 5;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < rows - i - 1; j++)
            {
                Console.Write(" ");
            }

            for (int k = 0; k < 2 * i + 1; k++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}