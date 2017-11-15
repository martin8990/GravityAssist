using System.Collections.Generic;
[System.Serializable]
public class SubBody
{

    public List<string> symbols;
    public int StartingIndex;

    public SubBody(int startingIndex)
    {
        StartingIndex = startingIndex;
    }
}

