using System.Collections.Generic;
public static class AnsestorExtracter
{
    public static List<AnsestorToken> operate(int index, List<string> Symbols)
    {
        int count = index+2;
        bool FoundDotDot = false;
        bool inGeneric = false;
        AnsestorToken curIf = null;
        List<AnsestorToken> Interfaces = new List<AnsestorToken>();
        while (Symbols[count] != "{")
        {

            if (FoundDotDot == true && Symbols[count] == "<" )
            {
                inGeneric = true;
                Symbols[count] = null;
            }
            
            else if (FoundDotDot == true && Symbols[count] == ">")
            {
                inGeneric = false;
                Symbols[count] = null;
            }

            else if (FoundDotDot == true && Symbols[count] != ",")
            {
                if (curIf != null)
                {
                    if (inGeneric)
                    {
                        curIf.Generics.Add(Symbols[count]);
                        Symbols[count] = null;
                    }
                    else
                    {
                        Interfaces.Add(curIf);
                        curIf = new AnsestorToken(Symbols[count]);
                        Symbols[count] = null;
                    }
                }
                else
                {
                    curIf = new AnsestorToken(Symbols[count]);
                    Symbols[count] = null;
                }

            }
            if (FoundDotDot == false && Symbols[count] == ":")
            {
                Symbols[count] = null;
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
public class AnsestorToken
{
    public string name;
    public List<string> Generics = new List<string>();

    public AnsestorToken(string name)
    {
        this.name = name;
    }
}