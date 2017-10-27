using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public static class KeyWordFinder
{
    static bool foundKeyword;
    static bool foundBody;

    static List<string> SubbodySymbols = new List<string>();

    public static List<int> FindKeyWords (List<string> input,string keyword)
    {
         List<int> indices = new List<int>();
         for (int i = 0; i < input.Count; i++)
         {
            if (input[i] == keyword)
            {
                indices.Add(i);
                input[i] = null;
            }
         }

        return indices;
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




