// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World! Welcome to Day 2 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

Console.WriteLine("My total score in round 1: " + part1(lines));
Console.WriteLine();
Console.WriteLine("My total score in round 2: " + part2(lines));

/*  ROCK = A, PAPER = B, SCISSOR = C
 *  ROCK = X, PAPER = Y, SCISSOR = Z
 */
static int part1(string[] lines)
{
    int score = 0;

    foreach(var line in lines)
    {
        string[] plays = line.Split(' ');
        if (plays[0].Equals("A"))
        {
            if (plays[1].Equals("X"))
            {
                score += 4;
            }
            else if (plays[1].Equals("Y"))
            {
                score += 8;
            }
            else if (plays[1].Equals("Z"))
            {
                score += 3;
            }
        }
        else if (plays[0].Equals("B"))
        {
            if (plays[1].Equals("X"))
            {
                score += 1;
            }
            else if (plays[1].Equals("Y"))
            {
                score += 5;
            }
            else if (plays[1].Equals("Z"))
            {
                score += 9;
            }
        }
        else if (plays[0].Equals("C"))
        {
            if (plays[1].Equals("X"))
            {
                score += 7;
            }
            else if (plays[1].Equals("Y"))
            {
                score += 2;
            }
            else if (plays[1].Equals("Z"))
            {
                score += 6;
            }
        }
    }
    return score;
}

/* ROCK = A, PAPER = B, SCISSOR = C
 * LOSE = X, DRAW = Y, WIN = Z
 */
static int part2(string[] lines)
{
    int score = 0;

    foreach (var line in lines)
    {
        string[] plays = line.Split(' ');
        if (plays[0].Equals("A"))
        {
            if (plays[1].Equals("X"))
            {
                score += 3;
            }
            else if (plays[1].Equals("Y"))
            {
                score += 4;
            }
            else if (plays[1].Equals("Z"))
            {
                score += 8;
            }
        }
        else if (plays[0].Equals("B"))
        {
            if (plays[1].Equals("X"))
            {
                score += 1;
            }
            else if (plays[1].Equals("Y"))
            {
                score += 5;
            }
            else if (plays[1].Equals("Z"))
            {
                score += 9;
            }
        }
        else if (plays[0].Equals("C"))
        {
            if (plays[1].Equals("X"))
            {
                score += 2;
            }
            else if (plays[1].Equals("Y"))
            {
                score += 6;
            }
            else if (plays[1].Equals("Z"))
            {
                score += 7;
            }
        }
    }
    return score;
}