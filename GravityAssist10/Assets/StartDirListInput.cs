using System.Collections.Generic;
using UnityEngine;
public class StartDirListInput : MonoBehaviour
{
    public List<string> directories = new List<string>();
    public FileFromDirMachine fileFromDirMachine;
    public LinesFromFileMachine linesFromFile;
    public FileSymbolsFromFileLinesMachine symbolsFromFileLinesMachine;
    void Start()
    {
      var files = fileFromDirMachine.Operate(directories);
      var lines = linesFromFile.Operate(files);
      var symbols =  symbolsFromFileLinesMachine.Operate(lines);

    }

}
public interface IComponent
{ }
