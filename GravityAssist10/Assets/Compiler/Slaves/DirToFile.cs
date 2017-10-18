using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class DirToFile {


    public static List<string> Operate(List<string> input)
    {
        var output = new List<string>();
        foreach (var dir in input)
        {
            ProcessDirectory(dir,output);
        }

        return output;
    }

    public static void ProcessDirectory(string targetDirectory,List<string> output)
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
            ProcessDirectory(subdirectory,output);
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