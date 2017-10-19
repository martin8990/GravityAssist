using System.Collections.Generic;
using UnityEngine;
public class Compiler : MonoBehaviour
{
    public List<string> directories = new List<string>();
    public List<char> Seperators;


    List<string> files;
    List<FileLines> fileLines;
    List<SymbolsPerFile> WordsPerFile;
    List<SymbolsPerFile> symsPerFile;
    public List<FileBody> FileBodies;

    public void Compile()
    {
        files = DirToFile.Operate(directories);
        fileLines = FileToLines.Operate(files);
        WordsPerFile = LinesToWords.Operate(fileLines);
        symsPerFile = WordsToSymbols.Operate(WordsPerFile, Seperators);
        FileBodies = FileBodyFromSymbols.Operate(symsPerFile);
        foreach (var filebody in FileBodies)
        {
            filebody.structBodies = StructExtracter.Operate(filebody.UnidentifiedSymbols);
            filebody.classBodies = ClassExtracter.Operate(filebody.UnidentifiedSymbols);
            filebody.usingStatements = UsingStatementExtracter.Operate(filebody.UnidentifiedSymbols);
        }
    }

}
public interface IComponent
{ }
