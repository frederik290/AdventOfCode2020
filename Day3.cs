using System.Collections.Generic;
using System.Linq;
public class TobogganTrajectory
{
    public void Run()
    {
        var input = InputReader.GetInputLinesForDay("Day3");
        var numberOfTreesFor3right1Down = GetTreesForMap(input, 3, 1);
        var numberOfTreesFor1right1Down = GetTreesForMap(input, 1, 1);
        var numberOfTreesFor5right1Down = GetTreesForMap(input, 5, 1);
        var numberOfTreesFor7right1Down = GetTreesForMap(input, 7, 1);
        var numberOfTreesFor1right2Down = GetTreesForMap(input, 1, 2);

        numberOfTreesFor3right1Down.ToString().Dump();
        numberOfTreesFor1right1Down.ToString().Dump();
        numberOfTreesFor5right1Down.ToString().Dump();
        numberOfTreesFor7right1Down.ToString().Dump();
        numberOfTreesFor1right2Down.ToString().Dump();

    }

    private int GetTreesForMap(List<string> input, int xSlopo, int ySlope)
    {
        var numberOfTrees = 0;
        var xPos = 0;

        for (var yPos = 0; yPos < input.Count; yPos += ySlope)
        {
            var line = input[yPos];
            var charToCheck = line[xPos % line.Length];
            var isTree = charToCheck.Equals('#');

            if (isTree)
                numberOfTrees++;

            xPos += xSlopo;
        }

        return numberOfTrees;
    }
}