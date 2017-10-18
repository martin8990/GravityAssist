using System.Collections.Generic;
[System.Serializable]
public class BodyType
{
    public string name;
    public string keyWord;
    public List<string> modifiers;
    public bool hasArguments;
}

[System.Serializable]
public class Modifier
{
    public string name;
    public bool has;

}

[System.Serializable]
public class Body
{
    public List<Body> subBodies = new List<Body>();
    public BodyType bodyType;
    public List<string> symbols = new List<string>();
    public List<string> modifiers = new List<string>();
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




