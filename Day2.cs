// Example password: 6-9 d: dddddkzdl
using System.Linq;
public class PasswordPhilosophy
{
    public void Run()
    {
        var input = InputReader.GetInputForDay("Day2");
        var validForFirstPolicy = 0;
        var validForSecondPolicy = 0;

        foreach (var item in input)
        {
            if (IsValidPassForFirstPolicy(item))
                validForFirstPolicy++;

            if (IsValidPassForSecondPolicy(item))
                validForSecondPolicy++;
        }

        $"Passes valid for first policy: {validForFirstPolicy}".Dump();
        $"Passes valid for second policy: {validForSecondPolicy}".Dump();
    }

    private bool IsValidPassForSecondPolicy(string passWithPolicy)
    {
        var indexes = passWithPolicy.Split(' ')[0];
        var index1 = int.Parse(indexes.Split('-')[0]);
        var index2 = int.Parse(indexes.Split('-')[1]);
        var charToCheckFor = passWithPolicy.Split(' ')[1].Trim(':');
        var pass = passWithPolicy.Split(' ')[2];

        var charAt1 = pass[index1-1].ToString();
        var charAt2 = pass[index2-1].ToString();

        //$"Item: {passWithPolicy}".Dump();
        //$"index1: {index1}, index2: {index2}, charToCheckFor: {charToCheckFor}, pass: {pass}, charAt1: {charAt1}, charAt2: {charAt2}".Dump();
        
        return charAt1.Equals(charToCheckFor) && !charAt2.Equals(charToCheckFor)
        || !charAt1.Equals(charToCheckFor) && charAt2.Equals(charToCheckFor);
    }

    private bool IsValidPassForFirstPolicy(string passWithPolicy)
    {
        var minAndMax = passWithPolicy.Split(' ')[0];
        var min = int.Parse(minAndMax.Split('-')[0]);
        var max = int.Parse(minAndMax.Split('-')[1]);
        var charToCheckFor = passWithPolicy.Split(' ')[1].Trim(':');
        var pass = passWithPolicy.Split(' ')[2];
        var foundCount = pass.AllIndexesOf(charToCheckFor).ToList().Count;

        //$"Item: {passWithPolicy}".Dump();
        //$"min: {min}, max: {max}, charToCheckFor: {charToCheckFor}, pass: {pass}, foundCount: {foundCount}".Dump();

        return (min <= foundCount && foundCount <= max);

    }
}