using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class PassportProcessing
{
    // Example passport: 
    // hcl:#6b5442 ecl:brn iyr:2019
    // pid:637485594 hgt:171cm
    // eyr:2021 byr:1986
    private static readonly string _BYR = "byr";
    private static readonly string _IYR = "iyr";
    private static readonly string _EYR = "eyr";
    private static readonly string _HGT = "hgt";
    private static readonly string _HCL = "hcl";
    private static readonly string _ECL = "ecl";
    private static readonly string _PID = "pid";
    private static readonly string _CID = "cid";
    private static string _requiredPassportPartsAsSortedString;

    public void Run()
    {
        _requiredPassportPartsAsSortedString = GetRequiredPassportPartsAsSortedString();

        var inputString = InputReader.GetInputStringForDay("Day4");
        var passports = GetPassportsFromString(inputString);
        var numberOfValidPassports = 0;

        var temp = new List<string>{};


        foreach (var passport in passports)
        {
            var parts = GetPassportPartsFromString(passport);

            if (PassportHasRequiredParts(parts) && PassportHasValidData(parts, passport))
                numberOfValidPassports++;
        }

        $"{numberOfValidPassports} valid passports".Dump();
    }

    private bool PassportHasValidData(string[] parts, string passport)
    {
        var byr = parts.Where(p => p.StartsWith(_BYR)).Select(p => p.Split(':')[1]).First();
        var iyr = parts.Where(p => p.StartsWith(_IYR)).Select(p => p.Split(':')[1]).First();
        var eyr = parts.Where(p => p.StartsWith(_EYR)).Select(p => p.Split(':')[1]).First();
        var hgt = parts.Where(p => p.StartsWith(_HGT)).Select(p => p.Split(':')[1]).First();
        var hcl = parts.Where(p => p.StartsWith(_HCL)).Select(p => p.Split(':')[1]).First();
        var ecl = parts.Where(p => p.StartsWith(_ECL)).Select(p => p.Split(':')[1]).First();
        var pid = parts.Where(p => p.StartsWith(_PID)).Select(p => p.Split(':')[1]).First();

        //BYR
        if (!IsYearBetween(1920, 2002, byr))
            return false;

        //IYR
        if (!IsYearBetween(2010, 2020, iyr))
            return false;

        //EYR
        if (!IsYearBetween(2020, 2030, eyr))
            return false;

        //HGT
        if(!HeightIsValid(hgt)) 
            return false;

        //HCL 
        var colorPattern = @"^#[a-f0-9]{6}$";
        var colorRegex = new Regex(colorPattern);
        if (!colorRegex.IsMatch(hcl))
            return false;

        //ECL
        var possibleEyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        var isKnownColor = possibleEyeColors.Any(possibleColor => possibleColor.Equals(ecl));
        if (!isKnownColor)
            return false;
           
        //PID
        var pidPattern = @"^\d{9}$";
        var pidRegex = new Regex(pidPattern);
        if (!pidRegex.IsMatch(pid))
            return false;

        return true;
    }

    private bool HeightIsValid(string hgt)
    {
        if (!(hgt.EndsWith("cm") || hgt.EndsWith("in")))
            return false;

        if (hgt.EndsWith("cm"))
        {
            var hgtValue = hgt.Split("cm")[0];
            if (int.Parse(hgtValue) < 150 || int.Parse(hgtValue) > 193)
            {
                return false;
            }

        }
        if (hgt.EndsWith("in"))
        {
            var hgtValue = hgt.Split("in")[0];
            if (int.Parse(hgtValue) < 59 || int.Parse(hgtValue) > 76)
            {
                return false;
            }

        }
        return true;
    }

    private bool IsYearBetween(int startYear, int endYear, string yearStringToCheck)
    {
        if (yearStringToCheck.Length != 4)
            return false;
        if (int.Parse(yearStringToCheck) < startYear || int.Parse(yearStringToCheck) > endYear)
            return false;

        return true;
    }

    private bool PassportHasRequiredParts(string[] parts)
    {
        var partsWithoutData = parts.Select(p => p.Split(':')[0]).ToList();
        partsWithoutData.Sort();
        partsWithoutData.Remove(_CID);
        var sortedPartsAsString = partsWithoutData.Aggregate((p0, p1) => p0 + p1);

        return sortedPartsAsString.Equals(_requiredPassportPartsAsSortedString);
    }

    private string GetRequiredPassportPartsAsSortedString()
    {
        var requiredParts = new List<string>
         {
            "byr", "iyr", "eyr", "hgt",
            "hcl", "ecl", "pid",
         };
        requiredParts.Sort();
        return requiredParts.Aggregate((p0, p1) => p0 + p1);
    }

    private string[] GetPassportPartsFromString(string passport)
    {
        var separator = new string[] { Environment.NewLine, " " };
        return passport.Split(separator, StringSplitOptions.RemoveEmptyEntries);

    }

    private string[] GetPassportsFromString(string inputString)
    {
        var separator = new string[] { Environment.NewLine + Environment.NewLine };
        return inputString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    }
}