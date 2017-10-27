using System.Collections.Generic;
public static class GenericsFinder
{
    public static List<string> Operate(int KeyWordIndex,List<string> Symbols)
    {
        if (Symbols[KeyWordIndex + 2] == "<")
        {
            Symbols[KeyWordIndex + 2] = null;
            var Generics = new List<string>();
            int GenIndex = KeyWordIndex + 3;
            while (Symbols[GenIndex] != ">")
            {
                if (Symbols[GenIndex] != ",")
                {
                    Generics.Add(Symbols[GenIndex]);
                }
                Symbols[GenIndex] = null;
                GenIndex++;
            }
            Symbols[GenIndex] = null;
            return Generics;
        }
        else return null;
    }
}
