using System.Collections.Generic;
public static class BodyGetter
{
    public static List<string> Operate(int index, List<string> symbols)
    {
        var bodySymbols = new List<string>();
        while (symbols[index] != "{")
        {
            index++;

        }
        index++;
        while (symbols[index] != "}")
        {
            bodySymbols.Add(symbols[index]);
            index++;
        }
        return bodySymbols;
    }
}
