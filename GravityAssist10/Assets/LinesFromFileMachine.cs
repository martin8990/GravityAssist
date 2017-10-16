using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LinesFromFileMachine : ScriptableObject, Machine<List<string>, List<FileLines>>
{
    public List<FileLines> output;
    public List<FileLines> Operate(List<string> input)
    {
        output = new List<FileLines>();
        foreach (var file in input)
        {
            output.Add(new FileLines(new List<string>(System.IO.File.ReadAllLines(file))));

        }
        return output;
    }
}

[CreateAssetMenu]
public class FileSymbolsFromFileLinesMachine : ScriptableObject, Machine<List<FileLines>, List<FileSymbols>>
{
    public List<char> Seperators;
    public List<FileSymbols> fileSymbols;
    List<string> currentFileSymbols;
    public List<FileSymbols> Operate(List<FileLines> input)
    {
        
        foreach (var Fileline in input)
        {
            currentFileSymbols = new List<string>();
            foreach (var line in Fileline.lines)
            {
                ProcessLine(line);
            }
            fileSymbols.Add(new FileSymbols(currentFileSymbols));
        }
        return fileSymbols;

    }
    public void ProcessLine(string Line)
    {
        for (int i = 0; i < Line.Length; i++)
        {       
            foreach (var sep in Seperators)
            {
                if (Line[i] == sep)
                {
                    if (i!=Line.Length-1)
                    {
                        
                    }
                }
            }
        }
    }

}
