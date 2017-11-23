using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public static class MathCommander
{
    static bool Interupted = false;
    static Dictionary<int, Action> UndoActionDict = new Dictionary<int, Action>();
    public static void ProcessLine(string Line, int lineNumber)
    {
        Interupt();
        if (UndoActionDict.ContainsKey(lineNumber))
        {
            UndoActionDict[lineNumber]();
        }
        
        if (Line.Length>0)
        {
            var Tokens = PreInterpreter.InterpretLine(Line, lineNumber);
            Interpreter.InterpretTokens(Tokens);
        }
    }

    public static void Interupt()
    {

    }
}

