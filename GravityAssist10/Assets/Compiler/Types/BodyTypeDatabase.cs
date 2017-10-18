using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="BodyTypeDatabase")]
public class BodyTypeDatabase : ScriptableObject
{
    public List<BodyType> bodyTypes;
    public BodyType fileBodyType { get { return bodyTypes[0]; } }
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




