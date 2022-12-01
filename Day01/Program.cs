// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Hello, World! Welcome to Day 1 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

Console.WriteLine("The elf carrying most calories are carrying " + part1(lines) + " Calories");
Console.WriteLine();
Console.WriteLine("The sum of the three elves carrying most calories is " + part2(lines) + " Calories");

static int part1(string[] input)
{
    int totalCalories = 0;
    int elfCalories = 0;

    foreach (var line in input)
    {
        if (!string.IsNullOrEmpty(line))
            elfCalories += Int32.Parse(line);
        else
        {
            if (elfCalories > totalCalories) totalCalories = elfCalories;
            elfCalories = 0;
        }
    }
    return totalCalories;
}

static int part2(string[] input)
{
    int totalCalories = 0;
    int largestCal = 0;
    int secLargestCal = 0;
    int ThirdLargestCal = 0;

    foreach (var line in input)
    {
        if (!string.IsNullOrEmpty(line))
            totalCalories += Int32.Parse(line);
        else
        {
            if (totalCalories > largestCal)
            {
                ThirdLargestCal = secLargestCal;
                secLargestCal = largestCal;
                largestCal = totalCalories;
            }
            else if(totalCalories > secLargestCal)
            {
                ThirdLargestCal = secLargestCal;
                secLargestCal = totalCalories;
            }
            else if(totalCalories > ThirdLargestCal) 
            { 
                ThirdLargestCal = totalCalories;
            }
            totalCalories = 0;
        }
    }
    return largestCal + secLargestCal + ThirdLargestCal;
}