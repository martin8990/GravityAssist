using System.Collections.Generic;
using UnityEngine;
public static class ArgumentExtracter
{
    public static List<Argument> GetWIthType(List<string> symbols, int index)
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
    public static List<TypelessArguments> GetWithoutType(List<string> symbols, int index)
    {
        var args = new List<TypelessArguments>();
        if (symbols[index] == ")")
        {
            index--;
            var arg = new TypelessArguments();
            while (symbols[index] != "(")
            {
                if (symbols[index] == ",")
                {
                    args.Add(arg);
                    arg = new TypelessArguments();

                }
                else
                {
                    arg.arguments.Add(symbols[index]);
                    
                }
                symbols[index] = null;
                index--;
            }
            args.Add(arg);
        }
        else
        {
            Debug.Log("No Arguments");
        }
        return args;
    }

}

