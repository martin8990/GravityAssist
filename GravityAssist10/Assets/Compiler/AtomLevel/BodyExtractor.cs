using System.Collections.Generic;
public static class BodyExtractor
{
    public static List<string> Operate(int index, List<string> symbols)
    {
        var bodySymbols = new List<string>();
        while (symbols[index] != "{")
        {
            index++;

        }
        symbols[index] = null;
        index++;
        int counter = 0;
        while (symbols[index] != "}" || counter!=0)
        {
            if (symbols[index] == "{")
            {
                counter++;
            }
            if (symbols[index] == "}")
            {
                counter--;
            }
            bodySymbols.Add(symbols[index]);
            symbols[index] = null;
            index++;
        }
        symbols[index] = null;
        return bodySymbols;
    }
}
