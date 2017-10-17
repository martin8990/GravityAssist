using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LinesToWords : ScriptableObject, Machine<List<FileLines>, List<SymbolsPerFile>>
{
    public List<string> CurrentWords;
    public List<SymbolsPerFile> Output;
    public List<SymbolsPerFile> Operate(List<FileLines> input)
    {
        Output = new List<SymbolsPerFile>();
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
