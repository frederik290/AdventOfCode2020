using System.IO;
using System.Linq;
using System.Collections.Generic;

public static class InputReader
{
    public static List<string> GetInputForDay(string dayName)
    {
        try
        {
            var basePath = @"/Users/frederik290/Projects/CodeOfAdvent/Input";
            return File.ReadAllLines(basePath + "/" + dayName + ".txt").ToList();
        }
        catch (System.Exception)
        {
            System.Console.WriteLine($"Could not find input for {dayName}");
            throw;
        }
    }
}