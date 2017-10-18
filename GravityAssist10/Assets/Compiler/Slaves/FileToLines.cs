using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public static class FileToLines 
{
    public static List<FileLines> Operate(List<string> input)
    {
        var output = new List<FileLines>();
        foreach (var file in input)
        {
            output.Add(new FileLines(new List<string>(System.IO.File.ReadAllLines(file))));

        }
        return output;
    }
}
