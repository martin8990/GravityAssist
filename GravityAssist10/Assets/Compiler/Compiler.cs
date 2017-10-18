using System.Collections.Generic;
using UnityEngine;
public class Compiler : MonoBehaviour
{
    public List<string> directories = new List<string>();
    public List<char> Seperators;
    public BodyTypeDatabase bodyTypesDB;

    List<string> files;
    List<FileLines> fileLines;
    List<SymbolsPerFile> WordsPerFile;
    List<SymbolsPerFile> symsPerFile;
    public List<Body> FileBodies;
    public List<Body> KeywordBodies;

    public void Compile()
    {
        files = DirToFile.Operate(directories);
        fileLines = FileToLines.Operate(files);
        WordsPerFile = LinesToWords.Operate(fileLines);
        symsPerFile = WordsToSymbols.Operate(WordsPerFile, Seperators);
        FileBodies = FileBodyFromSymbols.Operate(symsPerFile,bodyTypesDB.bodyTypes[0]);
        KeywordBodies = FileBodiesToKeyWordBodies.Operate(FileBodies, bodyTypesDB);
    }

}
public interface IComponent
{ }
