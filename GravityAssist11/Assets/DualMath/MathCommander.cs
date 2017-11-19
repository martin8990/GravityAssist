using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public static class MathCommander
{
    static bool Interupted = false;
    static Dictionary<int, Action> UndoActionDict = new Dictionary<int, Action>();
    public static float ProcessLine(string Line, int lineNumber)
    {
        Interupt();
        if (UndoActionDict.ContainsKey(lineNumber))
        {
            UndoActionDict[lineNumber]();
        }
        
        if (Line.Length>0)
        {
            var Tokens = PreInterpreter.InterpretLine(Line, lineNumber);
            var Result = Interpreter.InterpretTokens(Tokens);
            return Result;
        }
        return 0;
        

    }

    public static void Interupt()
    {

    }
}

