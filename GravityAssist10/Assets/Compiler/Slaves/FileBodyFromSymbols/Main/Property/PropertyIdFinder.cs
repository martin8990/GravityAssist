using System.Collections.Generic;
public static class PropertyIdFinder
{
    public static List<int> Operate(List<int> subBodies, List<string> symbols)
    {
        var PropertyIds = new List<int>();
        for (int i = 0; i < subBodies.Count; i++)
        {
            if (symbols[subBodies[i] - 1] != ")")
            {
                PropertyIds.Add(subBodies[i]);
            }
        }
        return PropertyIds;
    }
}
