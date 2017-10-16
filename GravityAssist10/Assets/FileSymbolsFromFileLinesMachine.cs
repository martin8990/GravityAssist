using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class FileSymbolsFromFileLinesMachine : ScriptableObject, Machine<List<FileLines>, List<FileSymbols>>
{
    public List<char> Seperators;
    public List<FileSymbols> fileSymbols;
    List<string> CurrentWords;
    List<string> currentFileSymbols;
   
    
    public List<FileSymbols> Operate(List<FileLines> input)
    {
        
        foreach (var Fileline in input)
        {

            currentFileSymbols = new List<string>();
            CurrentWords = new List<string>();
            foreach (var line in Fileline.lines)
            {
                CurrentWords.AddRange(line.Split());
            }
            foreach (var word in CurrentWords)
            {
                ProcessWord(word);
            }

            fileSymbols.Add(new FileSymbols(currentFileSymbols));
        }
        return fileSymbols;

    }
    public void ProcessWord(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {       
            foreach (var sep in Seperators)
            {
                if (word[i] == sep || word[i] == ' ')
                {
                    string symbol = "";
                    for (int j = 0; j < i; j++)
                    {
                        symbol += word[i];
                    }
                    string sepSymbol = sep.ToString();
                    currentFileSymbols.Add(symbol);
                    currentFileSymbols.Add(sepSymbol);
                    word.Remove(0, i+1);
                    i = 0;
                }
            }
        }
    }

}
