// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Welcome to Day 8 of Advent Of Code");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

Console.WriteLine("Number of visible trees: " + part1(lines));
Console.WriteLine();
Console.WriteLine("Highest possible sceneryscore: " + part2(lines));



static int part1(string[] lines)
{
    var treeLines = new List<List<int>>();
    var visibleTrees = 0;

    foreach(var line in lines)
    {
        var treeline = new List<int>();
        foreach(char c in line)
        {
            treeline.Add((int)(char.GetNumericValue(c)));
            
        }
        treeLines.Add(treeline);
    }

    for(int row = 0; row < treeLines.Count; row++)
    {
        for(int column = 0; column < treeLines[row].Count; column++)
        {
            if(row == 0 || row == treeLines.Count - 1 || column == 0 || column == treeLines[row].Count - 1)
            {
                visibleTrees++;
            }
            else
            {
                bool visible = true;
                bool added = false;
                for(int k = 0; k < row; k++)
                {
                    if (treeLines[k][column] >= treeLines[row][column])
                    {
                        visible = false;
                        break;
                    }
                }
                if(visible) {
                    visibleTrees++;
                    added = true;
                }
                if (!added)
                {
                    visible = true;
                    for (int k = row + 1; k < treeLines.Count; k++)
                    {
                        if (treeLines[k][column] >= treeLines[row][column])
                        {
                            visible = false;
                            break;
                        }
                    }
                    if (visible)
                    {
                        visibleTrees++;
                        added = true;
                    }
                }
                if (!added)
                {
                    visible = true;
                    for (int k = 0; k < column; k++)
                    {
                        if (treeLines[row][k] >= treeLines[row][column])
                        {
                            visible = false;
                            break;
                        }
                    }
                    if (visible)
                    {
                        visibleTrees++;
                        added = true;
                    }
                }

                if (!added)
                {
                    visible = true;
                    for (int k = column + 1; k < treeLines[row].Count; k++)
                    {
                        if (treeLines[row][k] >= treeLines[row][column])
                        {
                            visible = false;
                            break;
                        }
                    }
                    if (visible)
                    {
                        visibleTrees++;
                    }
                }

            }
        }
    }
    return visibleTrees;
}

static int part2(string[] lines)
{
    var treeLines = new List<List<int>>();
    var highestScore = 0;
    foreach (var line in lines)
    {
        var treeline = new List<int>();
        foreach (char c in line)
        {
            treeline.Add((int)(char.GetNumericValue(c)));

        }
        treeLines.Add(treeline);
    }
    for (int row = 1; row < treeLines.Count - 1; row++)
    {
        for (int column = 1; column < treeLines[row].Count - 1; column++)
        {
            var northScore = 0;
            var westScore = 0;
            var southScore = 0;
            var eastScore = 0;
            for (int k = row - 1; k >= 0; k--)
            {
                northScore++;
                if (treeLines[k][column] >= treeLines[row][column])
                {
                    break;
                }
            }
            for(int k = row + 1; k < treeLines.Count; k++)
            {
                southScore++;
                if (treeLines[k][column] >= treeLines[row][column])
                {
                    break;
                }
            }
            for(int k = column - 1; k >= 0; k--)
            {
                westScore++;
                if (treeLines[row][k] >= treeLines[row][column])
                {
                    break;
                }
            }
            for (int k = column + 1; k < treeLines[row].Count; k++)
            {
                eastScore++;
                if (treeLines[row][k] >= treeLines[row][column])
                {
                    break;
                }
            }
            var treeScore = northScore * westScore * southScore * eastScore;
            if (treeScore > highestScore){
                highestScore = treeScore;
            }
        }
    }
    return highestScore;
}
