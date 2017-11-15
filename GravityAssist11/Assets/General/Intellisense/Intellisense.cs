using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class Intellisense
{
    static int maxWords;
    static int index;
    static int maxSuggest;
    public static void AutofillTextboxes(InputField inputField,int maxSuggestions,List<string> Options,List<Text> texboxes)
    {
        if (inputField.text.Length > 0)
        {
            var similarWords = GetSimilarWords(inputField.text, Options, maxSuggestions, 0.5f);
            maxSuggest = maxSuggestions;
            maxWords = Mathf.Min(maxSuggestions, similarWords.Count);
            for (int i = 0; i < maxWords; i++)
            {
                texboxes[i].text = similarWords[i];
            }
            for (int i = maxWords; i < maxSuggestions; i++)
            {
                texboxes[i].text = "";
            }

        }
        index = 0;


    }
    public static IEnumerator UpdateIndex(List<KeyCode> upKeys, List<KeyCode> downKeys, float timeToWait, Color SelColor, Color UnSelColor, List<Image> images)
    {
        while (true)
        {
            foreach (var key in upKeys)
            {
                if (Input.GetKey(key))
                {
                    index++;
                    if (index >= maxWords)
                    {
                        index = 0;
                    }
                    yield return new WaitForSeconds(timeToWait);
                    HighLightSelected(SelColor, UnSelColor, images);
                }

            }
            foreach (var key in downKeys)
            {
                if (Input.GetKey(key))
                {
                    index--;
                    if (index < 0)
                    {
                        index = 0;
                    }
                    yield return new WaitForSeconds(timeToWait);
                    HighLightSelected(SelColor, UnSelColor, images);
                }

            }
            yield return null;
        }
        
    }

    public static void HighLightSelected(Color SelColor, Color UnSelColor, List<Image> images)
    {
        for (int i = 0; i < maxSuggest; i++)
        {
            if (i == index)
            {
                images[i].color = SelColor;
            }
            else
            {
                images[i].color = UnSelColor;
            }
        }
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
    

    // Draw recommend keyward(s)




}


