using System.Collections.Generic;
public static class ModifierFinder
{
    public static List<string> Operate(List<string> ModifierKeywords, List<string> Symbols, int index)
    {
        var modifiers = new List<string>();
        while (Symbols[index] != "}" && Symbols[index] != ";" && Symbols[index] != "]" && index!=-1)
        {
            foreach (var keyWord in ModifierKeywords)
            {
                if (Symbols[index] == keyWord)
                {
                    modifiers.Add(Symbols[index]);
                    Symbols[index] = null;
                }
            }

            index--;
        }
        return modifiers;



    }
}
