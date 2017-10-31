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
        var m_CacheCheckList = new List<string>(System.Math.Min(maxShownCount, srcCnt)); // optimize memory alloc

        // Start with - slow
        for (int i = 0; i < srcCnt && m_CacheCheckList.Count < maxShownCount; i++)
        {
            if (uniqueSrc[i].ToLower().StartsWith(input.ToLower()))
            {
                m_CacheCheckList.Add(uniqueSrc[i]);
                uniqueSrc.RemoveAt(i);
                srcCnt--;
                i--;
            }
        }

        // Contains - very slow
        if (m_CacheCheckList.Count == 0)
        {
            for (int i = 0; i < srcCnt && m_CacheCheckList.Count < maxShownCount; i++)
            {
                if (uniqueSrc[i].ToLower().Contains(input.ToLower()))
                {
                    m_CacheCheckList.Add(uniqueSrc[i]);
                    uniqueSrc.RemoveAt(i);
                    srcCnt--;
                    i--;
                }
            }
        }

        m_CacheCheckList.OrderBy(aux => aux.Length);
        return m_CacheCheckList;
    }

    // Draw recommend keyward(s)




}


