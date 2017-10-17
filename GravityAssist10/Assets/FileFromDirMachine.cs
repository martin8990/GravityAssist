using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu]
public class FileFromDirMachine : ScriptableObject,Machine<List<string>,List<string>> {


    public List<string> output;
    public List<string> Operate(List<string> input)
    {
        output = new List<string>();
        foreach (var dir in input)
        {
            ProcessDirectory(dir);
        }

        return output;
    }

    public void ProcessDirectory(string targetDirectory)
    {
        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
        {
            if (Path.GetExtension(fileName) != ".meta")
            {
                output.Add(fileName);
            }
        }
        // Recurse into subdirectories of this directory.
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory);
    }
}

public interface Master<T>
{

}
public interface slave<T>
{

}
public interface Machine<Input, Output>
{
    Output Operate(Input input);
}