using System.Collections.Generic;
using UnityEngine;

public static class BodyExtractor
{
    public static List<string> Operate(int index, List<string> symbols)
    {
        var bodySymbols = new List<string>();
        while (symbols[index] != "{")
        {
            index++;

        }
        symbols[index] = null;
        index++;
        int counter = 0;
        while (symbols[index] != "}" || counter!=0)
        {
            if (symbols[index] == "{")
            {
                counter++;
            }
            if (symbols[index] == "}")
            {
                counter--;
            }
            bodySymbols.Add(symbols[index]);
            symbols[index] = null;
            index++;
        }
        symbols[index] = null;
        return bodySymbols;
    }

    public static List<List<string>> OperateFlex(int index, List<string> symbols,string BodyOpener, string BodyCloser)
    {
        var Bodies = new List<List<string>>();
        var bodySymbols = new List<string>();
      
        while (index<symbols.Count)
        {
            while (index < symbols.Count && symbols[index] != BodyOpener)
            {
                index++;

            }
            
            index++;
            if (index < symbols.Count)
            {
                
                symbols[index-1] = null;
                int counter = 0;
                while (index < symbols.Count && symbols[index] != BodyCloser || counter != 0)
                {
                    if (symbols[index] == BodyOpener)
                    {
                        counter++;
                    }
                    if (symbols[index] == BodyCloser)
                    {
                        counter--;
                    }
                    bodySymbols.Add(symbols[index]);
                 
                    symbols[index] = null;
                    index++;
                }
                if (index < symbols.Count)
                {
                    symbols[index] = null;
                }
                index++;
                Bodies.Add(bodySymbols);
                
            }
          
        }        
        return Bodies;
    }
}
