using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu]
public class WordsToSymbols : ScriptableObject, Machine<List<SymbolsPerFile>, List<SymbolsPerFile>>
{
    public List<char> Seperators;

    public List<SymbolsPerFile> fileSymbols;
    List<string> currentSymbols;


    public List<SymbolsPerFile> Operate(List<SymbolsPerFile> input)
    {
        fileSymbols = new List<SymbolsPerFile>();
        foreach (var wordsPerFile in input)
        {
            currentSymbols = new List<string>();
            foreach (var word in wordsPerFile.Symbols)
            {
                ProcessWord(word);
            }

            fileSymbols.Add(new SymbolsPerFile(currentSymbols));
        }
        return fileSymbols;


    }
    public void ProcessWord(string word)
    {
        var symbol = "";
        for (int i = 0; i < word.Length; i++)
        {

            if (!isSeperator(word[i]))
            {
                symbol += word[i];
            }
            else
            {
                if (symbol.Length>0)
                {
                    currentSymbols.Add(symbol);
                }
                currentSymbols.Add(word[i].ToString());
                symbol = "";
            }
        }


        if (symbol != null && symbol.Length > 0)
        {
            currentSymbols.Add(symbol);
        }

    }
    bool isSeperator(char letter)
    {
        var result = false;
        foreach (var sep in Seperators)
        {
            if (letter == sep)
            {
                result = true;
            }
        }
        return result;
    }

}

