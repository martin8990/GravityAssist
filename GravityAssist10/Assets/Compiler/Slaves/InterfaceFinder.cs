using System.Collections.Generic;
public static class InterfaceFinder
{
    public static List<InterfaceToken> operate(int index, List<string> Symbols)
    {
        int count = index+2;
        bool FoundDotDot = false;
        bool inGeneric = false;
        InterfaceToken curIf = null;
        List<InterfaceToken> Interfaces = new List<InterfaceToken>();
        while (Symbols[count] != "{")
        {

            if (FoundDotDot == true && Symbols[count] == "<" )
            {
                inGeneric = true;
            }
            
            else if (FoundDotDot == true && Symbols[count] == ">")
            {
                inGeneric = false;
            }

            else if (FoundDotDot == true && Symbols[count] != ",")
            {
                if (curIf != null)
                {
                    if (inGeneric)
                    {
                        curIf.Generics.Add(Symbols[count]);
                    }
                    else
                    {
                        Interfaces.Add(curIf);
                        curIf = new InterfaceToken(Symbols[count]);
                    }
                }
                else
                {
                    curIf = new InterfaceToken(Symbols[count]);
                }

            }
            if (FoundDotDot == false && Symbols[count] == ":")
            {
                FoundDotDot = true;
            }
            count++;
        }
        if (curIf!=null)
        {
            Interfaces.Add(curIf);
        }
        return Interfaces;
    }
}
[System.Serializable]
public class InterfaceToken
{
    public string name;
    public List<string> Generics = new List<string>();

    public InterfaceToken(string name)
    {
        this.name = name;
    }
}