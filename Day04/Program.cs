// See https://aka.ms/new-console-template for more information
using System.Runtime.ExceptionServices;

Console.WriteLine("Hello, World! Welcome to Day 4 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

Console.WriteLine("Number of pairs fully containing each other: " + part1(lines));
Console.WriteLine();
Console.WriteLine("Number of overlaps: " + part2(lines));

static int part1(string[] lines)
{
    int pairs = 0;

    foreach (var line in lines)
    {
        var stringPairs = line.Split(',');
        var firstPair = stringPairs[0].Split('-');
        var secondPair = stringPairs[1].Split('-');
        if (int.Parse(firstPair[0]) >= int.Parse(secondPair[0]) && int.Parse(firstPair[1]) <= int.Parse(secondPair[1]) ||
            int.Parse(secondPair[0]) >= int.Parse(firstPair[0]) && int.Parse(secondPair[1]) <= int.Parse(firstPair[1]))
        {
            pairs++;
        }
    }

    return pairs;
}
// Want to try using intersect which i saw many people use in yesterdays solution
static int part2(string[] lines)
{
    int overlaps = 0;

    foreach(var line in lines)
    {
        var stringPairs = line.Split(',');
        var firstPair = stringPairs[0].Split('-');
        var secondPair = stringPairs[1].Split('-');
        var list1 = new List<int>();
        var list2 = new List<int>();

        if (!firstPair[0].Equals(firstPair[1]))
        {
            for (int i = int.Parse(firstPair[0]); i < int.Parse(firstPair[1]) + 1; i++)
            {
                list1.Add(i);
            }
        }
        else
            list1.Add(int.Parse(firstPair[0]));

        if (!secondPair[0].Equals(secondPair[1]))
        {
            for (int i = int.Parse(secondPair[0]); i < int.Parse(secondPair[1]) + 1; i++)
            {
                list2.Add(i);
            }
        }
        else
            list2.Add(int.Parse(secondPair[0]));


        var overlapsItems1 = list1.Intersect(list2).Count();
        var overlapsItems2 = list2.Intersect(list1).Count();
        if (overlapsItems1 != 0 || overlapsItems2 != 0)
        {
            overlaps++;
        }
    }
    return overlaps;
}