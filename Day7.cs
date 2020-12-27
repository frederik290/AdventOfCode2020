using System.Collections.Generic;
using System.Linq;

public class HandyHaversacks
{
    public void Run()
    {
        var input = InputReader.GetInputLinesForDay("Day7");
        var allBags = input.Select(i => new Bag(i));
        
        var flatListOfCandidateBags = GetListOfCandidateBags(allBags.ToList());
        var flatListOfBagRules = flatListOfCandidateBags.Select(b => b.Rule);
        var flatListOfDestinctBagRules = flatListOfBagRules.Distinct();

        $"Number of bags that could contain a shiny gold bag (directly or indirectly) is: {flatListOfDestinctBagRules.Count()}".Dump();
    }

    private List<Bag> GetListOfCandidateBags(List<Bag> allBags)
    {
        var primaryBags = allBags.Where(b => b.Content.Contains("shiny gold")).ToList();

        var shouldDoAnotherLoop = false;
        var bagLists = new List<List<Bag>>();
        var bagIndex = 0;

        bagLists.Add(primaryBags);

        do
        {
            var newBagList = new List<Bag>();
            shouldDoAnotherLoop = false;

            foreach (var bagToCheck in bagLists[bagIndex])
            {
                foreach (var bag in allBags)
                {
                    var currentBagCanContainAShinyGolgBag = bag.Content.Contains(bagToCheck.Description);
                    
                    if (currentBagCanContainAShinyGolgBag)
                    {
                        shouldDoAnotherLoop = true;
                        newBagList.Add(bag);
                    }

                }
            }
            bagIndex++;
            bagLists.Add(newBagList);

        }
        while (shouldDoAnotherLoop);

        return bagLists.SelectMany(b => b).ToList();
    }
}



public class Bag
{
    public Bag(string rule)
    {
        this.Rule = rule;
        this.Content = rule.Split("contain")[1];
        this.Description = rule.Split(" ").Take(2).Aggregate((a, b) => $"{a} {b}");
    }
    public string Rule { get; }
    public string Description { get; }
    public string Content { get; }

    public override string ToString()
    {
        return this.Rule;
    }


}