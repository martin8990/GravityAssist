using System.Collections.Generic;

public static class MethodExtracter
{
    public static List<MethodBody> Operate(List<string> symbols, List<int> subBodies)
    {
        var mBodies = new List<MethodBody>();
        var ids = MethodFinder.Operate(subBodies, symbols);
        var mods = new List<string> { "public", "private", "static", "abstract", "protected", "internal" };
        foreach (var id in ids)
        {
            var newMethodBody = new MethodBody();
            newMethodBody.modifiers = ModifierFinder.Operate(mods, symbols, id);
            newMethodBody.Generics = GenericsFinder.Operate(id - 7, symbols);
            newMethodBody.arguments = ArgumentExtracter.Operate(symbols, id);

            newMethodBody.name = MethodNameFinder.Operate(symbols,id);
            newMethodBody.returnType = MethodNameFinder.Operate(symbols, id);
            

            newMethodBody.symbols = BodyExtractor.Operate(id, symbols);
            
            mBodies.Add(newMethodBody);
        }
        SymbolCleaner.Operate(symbols);
        return mBodies;
    }
}
[System.Serializable]
public class Argument
{
    public string name;
    public string type;
    public bool generic;

    public Argument(string name, string type)
    {
        this.name = name;
        this.type = type;
    }
}

