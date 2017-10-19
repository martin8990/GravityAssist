using System.Collections.Generic;
public static class NameFinder
{
    public static string Operate(int KeyWordIndex, List<string> symbols)
    {
        var name = symbols[KeyWordIndex+1];
        symbols[KeyWordIndex + 1] = null;
        return name;
    }
}
