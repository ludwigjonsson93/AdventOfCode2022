// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Welcome to Day 5 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

part1(lines);
Console.WriteLine();
part2(lines);

/*Console.WriteLine("My total score in round 1: " + part1(lines));
Console.WriteLine();
Console.WriteLine("My total score in round 2: " + part2(lines));*/

static void part1(string[] lines)
{
    List<string> startPositions = new List<string>();
    List<Stack<char>> stacks = new List<Stack<char>>();
    stacks.AddRange(new List<Stack<char>>
    {
        new Stack<char>(), new Stack<char>(),  new Stack<char>(), new Stack<char>(), new Stack<char>(),  new Stack<char>(), new Stack<char>(), new Stack<char>(),  new Stack<char>()
    });

    startPositions.Add("");
    for (int i = 0; i < 8; i++)
    {
        startPositions.Add(lines[i]);
    }

    for(int i = 8; i > 0; i--)
    {
        for(int j = 0; j < stacks.Count; j++)
        {
            string boxChar = startPositions[i].Substring((j * 4) + 1, 1);
            if (!string.IsNullOrWhiteSpace(boxChar))
            {
                stacks[j].Push(char.Parse(boxChar));
            }
        }
    }

    for(int i = 10; i < lines.Length; i++)
    {
        string[] splits = lines[i].Split(' ');
        var amount = int.Parse(splits[1]);
        var origin = int.Parse(splits[3]);
        var destination = int.Parse(splits[5]);

        for(int j = 0; j < amount; j++)
        {
            var popped = stacks[origin - 1].Pop();
            stacks[destination - 1].Push(popped);
        }
    }

    Console.Write("Top Stack Message Part 1; ");
    foreach(var stack in stacks)
    {
        Console.Write(stack.Peek());
    }
}

static void part2(string[] lines)
{
    List<string> startPositions = new List<string>();
    List<Stack<char>> stacks = new List<Stack<char>>();
    stacks.AddRange(new List<Stack<char>>
    {
        new Stack<char>(), new Stack<char>(),  new Stack<char>(), new Stack<char>(), new Stack<char>(),  new Stack<char>(), new Stack<char>(), new Stack<char>(),  new Stack<char>()
    });

    startPositions.Add("");
    for (int i = 0; i < 8; i++)
    {
        startPositions.Add(lines[i]);
    }

    for (int i = 8; i > 0; i--)
    {
        for (int j = 0; j < stacks.Count; j++)
        {
            string boxChar = startPositions[i].Substring((j * 4) + 1, 1);
            if (!string.IsNullOrWhiteSpace(boxChar))
            {
                stacks[j].Push(char.Parse(boxChar));
            }
        }
    }

    for (int i = 10; i < lines.Length; i++)
    {
        string[] splits = lines[i].Split(' ');
        var amount = int.Parse(splits[1]);
        var origin = int.Parse(splits[3]);
        var destination = int.Parse(splits[5]);
        var blocks = new Stack<char>();

        if(amount == 1)
        {
            var popped = stacks[origin - 1].Pop();
            stacks[destination - 1].Push(popped);
        }
        else
        {
            for (int j = 0; j < amount; j++)
            {
                blocks.Push(stacks[origin - 1].Pop());
            }
            for(int j = 0; j < amount; j++)
            {
                stacks[destination - 1].Push(blocks.Pop());
            }
        }
    }

    Console.Write("Top Stack Message Part 2; ");
    foreach (var stack in stacks)
    {
        Console.Write(stack.Peek());
    }
}