using System.Collections.Generic;
using UnityEngine;
public class StartDirListInput : MonoBehaviour
{
    public List<string> directories = new List<string>();
    public FileFromDirMachine fileFromDirMachine;
    public LinesFromFileMachine linesFromFile;
    public LinesToWords wordsFromLinesMachine;
    public WordsToSymbols symbolsFromFileLinesMachine;
    

    void Start()
    {
      var files = fileFromDirMachine.Operate(directories);
      var lines = linesFromFile.Operate(files);
        var words = wordsFromLinesMachine.Operate(lines);
      var symbols =  symbolsFromFileLinesMachine.Operate(words);

    }

}
public interface IComponent
{ }
