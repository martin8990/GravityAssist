using System.Collections.Generic;
[System.Serializable]
public class FileLines
{
    public List<string> lines = new List<string>();
    
    public FileLines(List<string> lines)
    {
        this.lines = lines;
    }
}
