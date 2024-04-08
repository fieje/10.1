using System;
using System.IO;

public class Program
{
    static void Main()
    {
        string filePath = "text dot.txt";

        FindFourthDot(filePath, out int lineNumber, out int position);

        if (lineNumber == -1 || position == -1)
        {
            Console.WriteLine("Fourth dot not found in the file.");
        }
        else
        {
            Console.WriteLine($"Fourth dot found at line {lineNumber}, position {position}");
        }

        Console.ReadLine(); 
    }

    public static void FindFourthDot(string filePath, out int lineNumber, out int position)
    {
        lineNumber = -1;
        position = -1;

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                string line = lines[i];
                int dotCount = 0;

                for (int j = line.Length - 1; j >= 0; j--)
                {
                    if (line[j] == '.')
                    {
                        dotCount++;

                        if (dotCount == 4)
                        {
                            lineNumber = i + 1;
                            position = j + 1;
                            return;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}