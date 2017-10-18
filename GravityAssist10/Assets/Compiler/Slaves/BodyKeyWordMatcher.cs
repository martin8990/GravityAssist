using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public static class FileBodiesToKeyWordBodies
{
    static bool foundKeyword;
    static bool foundBody;
    static Body subBody;
    static BodyTypeDatabase bodyTypeDatabase;

    static List<string> SubbodySymbols = new List<string>();


    public static List<Body> Operate(List<Body> input,BodyTypeDatabase _bodyTypeDatabase)
    {
        bodyTypeDatabase = _bodyTypeDatabase;
        foreach (var body in input)
        {
            for (int i = 0; i < body.symbols.Count; i++)
            {
                FindKeyWords(body, i);

                AddToSubbodySymbols(body, i);
                FindBody(body, i);
            }

        }
        return input;
       
    }

    private static void AddToSubbodySymbols(Body body, int i)
    {
        if (foundBody == true && foundKeyword == true)
        {
            if (body.symbols[i] == "}")
            {
                foundBody = false;
                foundKeyword = false;
                subBody.symbols = SubbodySymbols;
            }
            else
            {
                SubbodySymbols.Add(body.symbols[i]);
            }
        }
    }

    private static void FindBody(Body body, int i)
    {
        if (foundBody == false && foundKeyword == true)
        {
            if (body.symbols[i] == "{")
            {
                foundBody = true;
                SubbodySymbols = new List<string>();
            }
        }
    }

    private static void FindKeyWords(Body body, int i)
    {
        if (foundKeyword == false)
        {
            foreach (var bodyType in bodyTypeDatabase.bodyTypes)
            {
                if (body.symbols[i] == bodyType.keyWord)
                {
                    subBody = new Body();
                    subBody.bodyType = bodyType;
                    body.subBodies.Add(subBody);
                    int j = i;
                    while (j >= 0 && body.symbols[j] != "}" && body.symbols[j] != ";")
                    {
                        foreach (var mod in bodyType.modifiers)
                        {
                            if (body.symbols[j] == mod)
                            {
                                body.modifiers.Add(mod);
                            }
                        }
                        j--;
                    }
                    foundKeyword = true;
                }
            }
        }
    }
}


















//public class ClassBody : Body
//{
//    public string Parent;
//    public List<string> Interfaces;
//    public bool Generic;
//    public string GenericParent;
//    public List<string> GenericInterfaces;
//}
//public class InterfaceBody : Body
//{
//    public bool Generic;

//}

//public class StructBody : Body
//{
//    public List<string> Interfaces;
//    public bool Generic;
//    public List<string> GenericInterfaces;

//}




