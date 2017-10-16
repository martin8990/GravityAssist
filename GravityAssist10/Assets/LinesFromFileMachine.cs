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
