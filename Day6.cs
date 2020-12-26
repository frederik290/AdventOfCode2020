using System;
using System.Collections.Generic;
using System.Linq;

public class CustomCustoms
{
    public void Run()
    {
        var inputString = InputReader.GetInputStringForDay("Day6");
        var groupAnswers = GetGroupAnswers(inputString).ToList();
        var totalNumberOfYesAnswers = 0;

        foreach (var groupAnswer in groupAnswers)
        {
           var answersForGroup = GetNumberOfYesAnswersFromGroup(groupAnswer);
           totalNumberOfYesAnswers += answersForGroup;
        }

        $"{totalNumberOfYesAnswers} is the total number of YES answers".Dump();

    }

    private int GetNumberOfYesAnswersFromGroup(string groupAnswer)
    {
        
        var setOfGroupAnswers = new HashSet<char>();
        var personAnswers = groupAnswer.Split(new string[]{Environment.NewLine}, StringSplitOptions.None);
        
        foreach (var personAnswer in personAnswers)
        {
            var markedQuestions = personAnswer.ToCharArray();
            setOfGroupAnswers.UnionWith(markedQuestions);
        }
        
        //To help get a sense of what is going on comment out the line below
        //DumpGroupInfo(groupAnswer, setOfGroupAnswers);

        return setOfGroupAnswers.Count();
    }

     private string[] GetGroupAnswers(string inputString)
    {
        var separator = new string[] { Environment.NewLine + Environment.NewLine };
        return inputString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    }

    private void DumpGroupInfo(string groupAnswer, HashSet<char> setOfGroupAnswers)
    {
        "######## Group answer string ########".Dump();
        groupAnswer.Dump();
        "######### Distinct YES answers ##########".Dump();
        setOfGroupAnswers.ToList().ForEach(i => i.ToString().Dump());
        $"Number distinct YES answers in group: {setOfGroupAnswers.Count()}".Dump();
    }
}