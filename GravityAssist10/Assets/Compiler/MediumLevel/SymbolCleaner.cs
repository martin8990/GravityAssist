using System.Collections.Generic;
public static class SymbolCleaner
{
    public static void Operate(List<string> symbols)
    {
        for (int i = 0; i < symbols.Count; i++)
        {
            
           symbols.RemoveAll(item => item == null);
            
        }
    }
}
