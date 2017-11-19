using System.Collections.Generic;
using UnityEngine;
public static class PreInterpreter
{
    static List<char> Separators = new List<char> { ';', ':', '+', '-', '^','(',')','*','/' };

    public static List<string> InterpretLine(string line, int LineNumber)
    {

        var tokens = GetTokens(line);
    
        return tokens;
    }

    static List<string> GetTokens(string line)
    {
        
        var SpaceSepTokens = new List<string>();
        var CharSeparatedTokens = new List<string>();
        if (line.Length>0)
        {
            SpaceSepTokens.AddRange(line.Split());
            
            for (int i = 0; i < SpaceSepTokens.Count; i++)
            {
                if (SpaceSepTokens[i].Length == 0)
                {
                    SpaceSepTokens.RemoveAt(i);
                    i--;
                }
                else
                {
                    WordsToSymbols.ProcessWord(SpaceSepTokens[i], CharSeparatedTokens, Separators);
                }
            }

            return CharSeparatedTokens;
        }
        return null;
    }
  



}