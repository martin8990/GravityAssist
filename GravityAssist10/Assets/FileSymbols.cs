using System.Collections.Generic;
[System.Serializable]
public class SymbolsPerFile
{
    public List<string> Symbols = new List<string>();

    public SymbolsPerFile(List<string> Symbols)
    {
        this.Symbols = Symbols;
    }
}
