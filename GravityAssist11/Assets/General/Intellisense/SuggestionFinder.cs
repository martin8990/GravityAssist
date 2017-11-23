using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class SuggestionFinder
{
    static int maxWords;
    static int index;
    static int maxSuggest;
    static bool NextEnterIsCommit = false;
    public static void GetSuggestions(string inputText,int maxSuggestions,List<string> Options,SuggestText suggestText)
    {
        var suggestions = new List<string>();
        if (inputText.Length > 0)
        {
            var similarWords = GetSimilarWords(inputText, Options, maxSuggestions, 0.5f);
            maxSuggest = maxSuggestions;
            maxWords = Mathf.Min(maxSuggestions, similarWords.Count);
            for (int i = 0; i < maxWords; i++)
            {
                suggestions.Add(similarWords[i]);
            }
            for (int i = maxWords; i < maxSuggestions; i++)
            {
                suggestions.Add("");
            }

        }
        suggestText.ShowSuggestions(Options);
    }


    public static List<string> GetSimilarWords(string input, List<string> words, int maxShownCount, float levenshteinDistance)
    {
        List<string> uniqueSrc = new List<string>(new HashSet<string>(words)); // remove duplicate
        int srcCnt = uniqueSrc.Count;
        var Results = new List<string>(System.Math.Min(maxShownCount, srcCnt)); // optimize memory alloc

        // Start with - slow
        for (int i = 0; i < srcCnt && Results.Count < maxShownCount; i++)
        {
            if (uniqueSrc[i].ToLower().StartsWith(input.ToLower()))
            {
                Results.Add(uniqueSrc[i]);
                uniqueSrc.RemoveAt(i);
                srcCnt--;
                i--;
            }
        }

        // Contains - very slow
        if (Results.Count == 0)
        {
            for (int i = 0; i < srcCnt && Results.Count < maxShownCount; i++)
            {
                if (uniqueSrc[i].ToLower().Contains(input.ToLower()))
                {
                    Results.Add(uniqueSrc[i]);
                    uniqueSrc.RemoveAt(i);
                    srcCnt--;
                    i--;
                }
            }
        }
        Results = Results.OrderBy(aux => aux.Length).ToList();

        return Results;
    }

}


