// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Welcome to Day 6 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

Console.WriteLine("Sum of priorities: " + part1(lines));
Console.WriteLine();
//Console.WriteLine("Sum of priorities for the three Elf groups: " + part2(lines));

static int part1(string[] lines)
{
    return 0;
}