// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World! Welcome to Day 9 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

static void part1(string[] lines)
{
    var head = (0, 0);
    var tail = (0, 0);
    List<Tuple<int, int>> visited = new List<Tuple<int, int>>();
    foreach(var line in lines)
    {
        string[] instructions = line.Split(' ');
        switch (instructions[0])
        {
            case "U":

                break;
            case "R":
                break;
            case "D":
                break;
            case "L":
                break;
        }
    }
}