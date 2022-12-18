// See https://aka.ms/new-console-template for more information
using System.Windows.Markup;

Console.WriteLine("Hello, World! Welcome to Day 7 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

Console.WriteLine("Total size of all directories with size less than or equal to 100000 is: " + part1(lines));
Console.WriteLine();
Console.WriteLine("Smallest size to remove in order to have 30000000 space free is: " + part2(lines));

static int part1(string[] lines)
{
    var directories = new Stack<string>();
    var fileSizes = new Dictionary<string, int>();
    var sum = 0;

    foreach(var line in lines)
    {
        if (line.Equals("$ cd .."))
        {
            directories.Pop();
        }
        else if (line.StartsWith("$ cd"))
        {
            directories.Push(string.Join("", directories) + line.Split(" ")[2]);
        }
        else if (char.IsDigit(line[0]))
        {
            var size = int.Parse(line.Split(" ")[0]);
            foreach(var d in directories)
            {
                fileSizes[d] = fileSizes.GetValueOrDefault(d) + size;
            }
        }
    }

    var values = fileSizes.Values.ToList();
    foreach(var val in values)
    {
        if(val <= 100000)
        {
            sum += val;
        }
    }

    return sum;
}

static int part2(string[] lines)
{
    var directories = new Stack<string>();
    var fileSizes = new Dictionary<string, int>();
    var smallestremoved = 0;

    foreach (var line in lines)
    {
        if (line.Equals("$ cd .."))
        {
            directories.Pop();
        }
        else if (line.StartsWith("$ cd"))
        {
            directories.Push(string.Join("", directories) + line.Split(" ")[2]);
        }
        else if (char.IsDigit(line[0]))
        {
            var size = int.Parse(line.Split(" ")[0]);
            foreach (var d in directories)
            {
                fileSizes[d] = fileSizes.GetValueOrDefault(d) + size;
            }
        }
    }

    var values = fileSizes.Values.ToList();
    var usedSpace = 70000000 - values.Max();
    smallestremoved = values.Max();
    foreach (var val in values)
    {
        if(usedSpace + val >= 30000000)
        {
            if(val < smallestremoved)
            {
                smallestremoved = val;
            }
        }
    }

    return smallestremoved;
}