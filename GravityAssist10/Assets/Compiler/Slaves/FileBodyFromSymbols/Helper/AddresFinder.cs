using System.Collections.Generic;
public static class AddresFinder
{
    public static List<string> Operate(List<string> symbols, int index)
    {
        List<string> Adress = new List<string>();
        while (symbols[index] != ";" && index < symbols.Count)
        {
            if (symbols[index] != "." && symbols[index]!= null)
            {
               Adress.Add(symbols[index]);
            }
            symbols[index] = null;
            index++;
        }
        if (symbols[index] == ";")
        {
            symbols[index] = null;
        }
        return Adress;
    }
}
