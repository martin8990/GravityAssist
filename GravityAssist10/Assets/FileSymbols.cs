using System.Collections.Generic;
[System.Serializable]
public class FileSymbols
{
    public List<string> Symbols = new List<string>();

    public FileSymbols(List<string> Symbols)
    {
        this.Symbols = Symbols;
    }
}
