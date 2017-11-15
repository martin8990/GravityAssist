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
    public List<ScriptBody> FileBodies;

    public void Compile()
    {
        files = DirToFile.Operate(directories);
        fileLines = FileToLines.Operate(files);
        WordsPerFile = LinesToWords.Operate(fileLines);
        symsPerFile = WordsToSymbols.Operate(WordsPerFile, Seperators);
        FileBodies = FileBodyFromSymbols.Operate(symsPerFile);
    
    }

}

public class ScriptBody
{
    internal List<string> UnidentifiedSymbols;
    internal List<StructBody> structBodies;
    internal List<ClassBody> classBodies;
    internal List<UsingStatement> usingStatements;
    internal List<InterfaceBody> interfaceBodies;
    internal List<EnumBody> enumBodies;
}

public interface IComponent
{ }
