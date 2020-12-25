using System;
using System.IO;
using System.Linq;

public class ExpenseFixer 
{
    public void Run()
    {
        var input = InputReader.GetInputLinesForDay("Day1");
        var numbers = input.Select(l => int.Parse(l));

        foreach(var i in numbers)
        {
            foreach (var j in numbers)
            {
                if(i + j == 2020)
                {
                    Console.WriteLine($"i: {i}, j {j}");
                    Console.WriteLine($"i*j: {i*j}");
                }

                foreach (var k in numbers)
                {
                    if(i + j + k == 2020)
                    {
                        Console.WriteLine($"i: {i}, j {j}, k: {k}");
                        Console.WriteLine($"i*j*k: {i*j*k}");
                    }
                }
            }
        }
    }
}