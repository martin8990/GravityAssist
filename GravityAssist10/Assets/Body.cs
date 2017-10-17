using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BodyType
{
    public bool hasKeyWord;
    public string keyWord;
    public List<string> symbols;
    public List<string> modifiers;
    public bool hasArguments;
}

[System.Serializable]
public class Modifier
{
    public string name;
    public bool has;

}

[CreateAssetMenu]
public class BodyTypeDatabase : ScriptableObject
{
    public List<BodyType> bodyTypes;
}

[System.Serializable]
public class Body
{
    public BodyType bodyType;
    public List<string> symbols;
    public List<string> modifiers;
}


public class BodyKeyWordMatcher : ScriptableObject, Machine<List<Body>, List<Body>>
{
    public BodyTypeDatabase bodyTypeDatabase;

    bool foundKeyword;
    bool foundBody;
    Body subBody;
    List<string> SubbodySymbols;
    public List<Body> Operate(List<Body> input)
    {
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

    private void AddToSubbodySymbols(Body body, int i)
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

    private void FindBody(Body body, int i)
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

    private void FindKeyWords(Body body, int i)
    {
        if (foundKeyword == false)
        {
            foreach (var bodyType in bodyTypeDatabase.bodyTypes)
            {
                if (body.symbols[i] == bodyType.keyWord)
                {
                    subBody = new Body();
                    subBody.bodyType = bodyType;
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
                    }
                    foundKeyword = true;
                }
            }
        }
    }
}

public static class SubBodySymbolTransfer
{


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




