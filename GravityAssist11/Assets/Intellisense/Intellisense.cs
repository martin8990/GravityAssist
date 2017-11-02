using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public static class Intellisense
{

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
        Debug.Log(Results[0]);
        Results = Results.OrderBy(aux => aux.Length).ToList();
        Debug.Log(Results[0]);
        return Results;
    }
    

    // Draw recommend keyward(s)




}


