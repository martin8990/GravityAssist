using System.Collections.Generic;
using UnityEngine;

public static class AddresFinder
{
    public static List<string> Operate(List<string> symbols, int index)
    {
        List<string> Adress = new List<string>();
        while (index < symbols.Count && symbols[index] != ";"  && symbols[index]!="(")
        {
            if (symbols[index] != "." && symbols[index]!= null)
            {
               Adress.Add(symbols[index]);
            }
            symbols[index] = null;
            index++;
        }
        if (index < symbols.Count && symbols[index] == ";" ) 
        {
            symbols[index] = null;
        }
        return Adress;
    }
}




[System.Serializable]
public class PropertyBody
{
    public string name;
    public string type;
    public List<string> modifiers;
    public bool generic;
    public List<string> symbols;
}