using System.Collections.Generic;
public static class UsingStatementExtracter
{
    public static List<UsingStatement> Operate(List<string> Symbols)
    {
        var UsingStatments = new List<UsingStatement>();
        var indices = KeyWordFinder.FindKeyWords(Symbols, "using");
        foreach (var index in indices)
        {
            var uStatement = new UsingStatement();
            uStatement.Addres = AddresFinder.Operate(Symbols, index);
            UsingStatments.Add(uStatement);
        }
        SymbolCleaner.Operate(Symbols);
        return UsingStatments;
    }
}
