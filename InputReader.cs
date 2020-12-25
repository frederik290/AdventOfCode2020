using System.IO;
using System.Linq;
using System.Collections.Generic;

public static class InputReader
{
    private static readonly string _basePath = @"/Users/frederik290/Projects/CodeOfAdvent/Input";
    public static List<string> GetInputLinesForDay(string dayName)
    {
        try
        {
            return File.ReadAllLines(_basePath + "/" + dayName + ".txt").ToList();
        }
        catch (System.Exception)
        {
            System.Console.WriteLine($"Could not find input for {dayName}");
            throw;
        }
    }

    public static string GetInputStringForDay(string dayName)
    {
        try
        {
            return File.ReadAllText(_basePath + "/" + dayName + ".txt");
        }
        catch (System.Exception)
        {
            
            System.Console.WriteLine($"Could not find input for {dayName}");
            throw;
        }
    }
}