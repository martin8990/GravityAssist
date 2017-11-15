using System.Collections.Generic;
public static class AtributeBodyExtractor
{
    public static List<List<string>> Operate(List<string> symbols, int index)
    {
        var bodies = new List<List<string>>();
     
        bool inAtribute = false;
        while (index >= 0 && symbols[index] != "}" && symbols[index] != "{" && symbols[index] != ";")
        {
            if (symbols[index] == "[")
            {
                symbols[index] = null;
                int AId = index + 1;
                var body = new List<string>();
                while (symbols[AId] != "]")
                {
                    body.Add(symbols[AId]);
                    symbols[AId] = null;
                    AId++;
                }
                bodies.Add(body);
            }
            index--;


        }
        return bodies;
    }

}

