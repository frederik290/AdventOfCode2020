using System;

public class BinaryBoarding
{
    public void Run()
    {
        var input = InputReader.GetInputLinesForDay("Day5");
        var highestSeatId = 0;

        foreach (var line in input)
        {
            var id = GetSeatIdFromString(line);

            if(id > highestSeatId)
                highestSeatId = id;
        }

        $"{highestSeatId} is the highest seat id".Dump();
       

    }

    private int GetSeatIdFromString(string seatString)
    {
        var rowPart = seatString.Substring(0, 7);
        var columnPart = seatString.Substring(7);
        
        var rowNumber = DoBinarySearch(rowPart, 0, 127);
        var columnNumber = DoBinarySearch(columnPart, 0, 7);
    
        return (rowNumber * 8) + columnNumber;
    }

    

    private int DoBinarySearch(string seatString, int lower, int upper)
    {
        $"seatString: {seatString}, lower:: {lower}, upper: {upper}".Dump();
        var seatChar = seatString[0];
        var distance = 0;

        if(seatString.Length == 1)
        {
            if(LowerHalfSeating(seatChar))
                return lower;
            else return upper;
            
        }
        
        var rest = seatString.Substring(1);

        if(LowerHalfSeating(seatChar))
        {
            distance =  (int)Math.Ceiling((double)(upper - lower) / 2);
            return DoBinarySearch(rest, lower, upper - distance);
        }
        else
        {
            distance =  (int)Math.Floor((double)(upper - lower) / 2);
            return DoBinarySearch(rest, upper - distance, upper);
        }

    }

    private bool LowerHalfSeating(char charToConsider)
    {
        return charToConsider.Equals('F') || charToConsider.Equals('L');;
    }
}