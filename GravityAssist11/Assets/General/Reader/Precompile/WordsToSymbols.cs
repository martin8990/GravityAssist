using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public static class WordsToSymbols 
{
    public static List<SymbolsPerFile> Operate(List<SymbolsPerFile> input,List<char> Seperators)
    {
        List<SymbolsPerFile> fileSymbols;
        List<string> currentSymbols;

        fileSymbols = new List<SymbolsPerFile>();
        foreach (var wordsPerFile in input)
        {
            currentSymbols = new List<string>();
            foreach (var word in wordsPerFile.Symbols)
            {
                ProcessWord(word,currentSymbols,Seperators);
            }

            fileSymbols.Add(new SymbolsPerFile(currentSymbols));
        }
        return fileSymbols;


    }
    public static void ProcessWord(string word,List<string> currentSymbols,List<char> Separators)
    {
        var symbol = "";
        for (int i = 0; i < word.Length; i++)
        {

            if (!isSeperator(word[i], Separators))
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

    public static void ProcessAddres(string word, List<string> currentSymbols, List<char> Separators)
    {
        var symbol = "";
        for (int i = 0; i < word.Length; i++)
        {

            if (!isSeperator(word[i], Separators))
            {
                symbol += word[i];
            }
            else
            {
                if (symbol.Length > 0)
                {
                    currentSymbols.Add(symbol);
                }
               
                symbol = "";
            }
        }


        if (symbol != null && symbol.Length > 0)
        {
            currentSymbols.Add(symbol);
        }

    }


    static bool isSeperator(char letter,List<char> Separators)
    {
        var result = false;
        foreach (var sep in Separators)
        {
            if (letter == sep)
            {
                result = true;
            }
        }
        return result;
    }

}

