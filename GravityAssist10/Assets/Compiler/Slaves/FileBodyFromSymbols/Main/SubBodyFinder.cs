using System.Collections.Generic;
using UnityEngine;

public static class MethodFinder
{
    public static List<int> Operate(List<int> subBodies,List<string> symbols)
    {
        var methodIds = new List<int>();
        for (int i = 0; i < subBodies.Count; i++)
        {
            if (symbols[subBodies[i]-1] == ")")
            {
                methodIds.Add(subBodies[i]);
                subBodies.Remove(subBodies[i]);
            }
        }
        return methodIds;
    }
}

public static class SubBodyFinder
{
    
    public static List<int> ExtractSubBodies(List<string> symbols)
    {
        var subBodies = new List<int>();
        int BodyLevel = 0;
        var currentSubBody = 0;
        for (int i = 0; i < symbols.Count; i++)
        {
            if (symbols[i] == "{")
            {
                BodyLevel++;
                if (BodyLevel == 1)
                {
                    currentSubBody = i;
                    
                }
            }
            if (symbols[i] == "}")
            {
                BodyLevel--;
                if (BodyLevel == 0)
                {
                    Debug.Log("Adding subbody");
                    subBodies.Add(currentSubBody);
                }                
            }
        }
        return subBodies;

    }
}

