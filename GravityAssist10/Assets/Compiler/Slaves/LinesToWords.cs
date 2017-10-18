using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public static class LinesToWords 
{
    public static  List<SymbolsPerFile> Operate(List<FileLines> input)
    {
        var Output = new List<SymbolsPerFile>();
        List<string> CurrentWords;
        
        foreach (var Fileline in input)
        {
            CurrentWords = new List<string>();
            foreach (var line in Fileline.lines)
            {
                CurrentWords.AddRange(line.Split());
            }
            for (int i = 0; i < CurrentWords.Count; i++)
            {
                if (CurrentWords[i].Length == 0)
                {
                    CurrentWords.RemoveAt(i);
                    i--;
                }
            }
            Output.Add(new SymbolsPerFile(CurrentWords));

        }
        return Output;
    }
}
