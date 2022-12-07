// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Welcome to Day 6 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

Console.WriteLine("Start of packet marker detected at index: " + part1(lines, 4));
Console.WriteLine();
Console.WriteLine("Start of message marker detected at index: " + part1(lines, 14));

static int part1(string[] lines, int size)
{
    int index = 0;
    for(int i = size; i < lines[0].Length; i++)
    {
        var sequence = lines[0].Skip(i - size).Take(size).ToList();
        if(sequence.Distinct().Count() == size)
        {
            index = i;
            break;
        }
    }
    return index;
}