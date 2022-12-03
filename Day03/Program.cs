// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World! Welcome to Day 3 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

Console.WriteLine("Sum of priorities: " + part1(lines));
Console.WriteLine();
Console.WriteLine("Sum of priorities for the three Elf groups: " + part2(lines));

static int part1(string[] lines)
{
    var prioSum = 0;

    foreach(var line in lines)
    {
        string first = line.Substring(0, line.Length / 2);
        string second = line.Substring((line.Length / 2), line.Length / 2);
        foreach(var c in first)
        {
            if (second.Contains(c))
            {
                if (char.IsUpper(c)) prioSum += c - 38;
                else prioSum += c - 96;
                break;
            }
        }
    }
    return prioSum;
}

static int part2(string[] lines)
{
    var prioSum = 0;
    for(int i = 0; i < lines.Length; i += 3)
    {
        var threeLines = lines.Skip(i).Take(3).ToList();
        foreach(char c in threeLines[0]) {
            if (threeLines[1].Contains(c) && threeLines[2].Contains(c)) {
                if (char.IsUpper(c)) prioSum += c - 38;
                else prioSum += c - 96;
                break;
            }
        }
    }
    return prioSum;
}