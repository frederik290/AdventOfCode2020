using System;
using System.Collections.Generic;
using System.Linq;

public class CustomCustoms
{
    public void Run()
    {
        var inputString = InputReader.GetInputStringForDay("Day6");
        var groupAnswers = GetGroupAnswers(inputString).ToList();
        var totalNumberOfYesAnswersGivenByEveryone = 0;
        var totalNumberOfYesAnswersGivenByAnyone = 0;

        foreach (var groupAnswer in groupAnswers)
        {
            var numberOfAnswersGivenByEveryone = GetNumberOfYesAnswersFromGroup(groupAnswer, YesAnswers.EVERYONE);
            totalNumberOfYesAnswersGivenByEveryone += numberOfAnswersGivenByEveryone;

            var numberOfAnswersGivenByAnyone = GetNumberOfYesAnswersFromGroup(groupAnswer, YesAnswers.ANYONE);
            totalNumberOfYesAnswersGivenByAnyone+= numberOfAnswersGivenByAnyone;
        }

        $"{totalNumberOfYesAnswersGivenByEveryone} is the total number of YES answers given by everyone".Dump();
        $"{totalNumberOfYesAnswersGivenByAnyone} is the total number of YES answers given by anyone".Dump();

    }

    private int GetNumberOfYesAnswersFromGroup(string groupAnswer, YesAnswers countType)
    {
        var personAnswers = groupAnswer.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        var numberOfYesAnswers = 0;
        
        if(countType.Equals(YesAnswers.ANYONE))
            numberOfYesAnswers = GetAnswersByUntion(personAnswers);

        if(countType.Equals(YesAnswers.EVERYONE))
            numberOfYesAnswers = GetAnswersByIntersection(personAnswers);

        return numberOfYesAnswers;
    }

    private int GetAnswersByIntersection(string[] personAnswers)
    {
        var charLists = new List<List<char>>();
        var result = new List<char>();

        foreach (var answerString in personAnswers)
            charLists.Add(answerString.ToCharArray().ToList());
        
        result = charLists.First();

        for (int i = 1; i < charLists.Count; i++)
        {
            var current = charLists[i];
            result = result.Intersect(current).ToList();
        }
        return result.Count;
    }

    private int GetAnswersByUntion(string[] personAnswers)
    {
        var setOfGroupAnswers = new HashSet<char>();
        foreach (var personAnswer in personAnswers)
        {
            var markedQuestions = personAnswer.ToCharArray();
            setOfGroupAnswers.UnionWith(markedQuestions);
        }
        return setOfGroupAnswers.Count();

       
    }

    private string[] GetGroupAnswers(string inputString)
    {
        var separator = new string[] { Environment.NewLine + Environment.NewLine };
        return inputString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    }
}

public enum YesAnswers
{
    EVERYONE,
    ANYONE
}