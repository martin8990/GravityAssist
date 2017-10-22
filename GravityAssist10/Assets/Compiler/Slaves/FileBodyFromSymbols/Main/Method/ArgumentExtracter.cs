using System.Collections.Generic;
using UnityEngine;
public static class ArgumentExtracter
{
    public static List<Argument> Operate(List<string> symbols, int index)
    {
        index--;
        var args = new List<Argument>();
        if (symbols[index] == ")")
        {
            index--;
            while (symbols[index] != "(")
            {
                if (symbols[index]!=",")
                {
                    var arg = new Argument(symbols[index - 1], symbols[index]);
                    symbols[index - 1] = null;
                    symbols[index ] = null;

                    index -= 2;
                    args.Add(arg);
                }
                else
                {
                    index--;
                }
            }
        }
        else
        {
            Debug.Log("No Arguments");
        }
        return args;
    }
}

