using System.Collections.Generic;

public static class Util
{
    public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
    {
        int minIndex = str.IndexOf(searchstring);
        while (minIndex != -1)
        {
            yield return minIndex;
            minIndex = str.IndexOf(searchstring, minIndex + 1);
        }
    }

    public static void Dump(this string str)
    {
        System.Console.WriteLine(str);
    }

    public static void Dump<T>(this IEnumerable<T> collection)
    {
        foreach (var item in collection)
            item.ToString().Dump();   
    }
}