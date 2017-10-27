using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public static class OutputTypeExtracter {

    public static MType GetOutputType(Type outputType, int maxDepth)
    {
        var type = new MType(outputType.ToString());
        
        foreach (var field in outputType.GetFields())
        {
            if (field.IsPublic)
            {
                GetSubType(type.subTypes, field, 1, maxDepth);

            }
        }

        
        return type;       
        

    }
    public static void GetSubType(List<SubType> list, FieldInfo field, int curDepth, int maxDepth)
    {
        var subType = new SubType(field.Name, field.FieldType.ToString());
        list.Add(subType);
        curDepth++;
        if (curDepth<=maxDepth)
        {
            foreach (var subField in field.FieldType.GetFields())
            {
                GetSubType(subType.subTypes, subField, curDepth, maxDepth);
            }
        }
        
    }

}

[System.Serializable]
public class MType
{
    public string Type;
    public List<SubType> subTypes = new List<SubType>();

    public MType(string type)
    {
        Type = type;
    }
}


[System.Serializable]
public class SubType
{
    public string FieldName;
    public string Type;
    public List<SubType> subTypes = new List<SubType>();

    public SubType(string fieldName, string type)
    {
        FieldName = fieldName;
        Type = type;
    }
}
