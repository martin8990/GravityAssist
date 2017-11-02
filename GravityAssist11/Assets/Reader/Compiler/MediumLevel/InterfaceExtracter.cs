using System.Collections.Generic;
public static class InterfaceExtracter
{
    public static List<InterfaceBody> Operate(List<string> Symbols)
    {
        var interfaceBodies = new List<InterfaceBody>();
        var indices = KeyWordFinder.FindKeyWords(Symbols, "interface");
        var keyWords = new List<string> { "partial", "public", "internal"};
        foreach (var index in indices)
        {
            var interfaceBody = new InterfaceBody();
            interfaceBody.name = NameFinder.Operate(index, Symbols);
            interfaceBody.Generics = GenericsFinder.Operate(index, Symbols);
            interfaceBody.Ancestors = AnsestorExtracter.operate(index, Symbols);
            interfaceBody.Modifiers = ModifierFinder.Operate(keyWords, Symbols, index);
            interfaceBody.Symbols = BodyExtractor.Operate(index, Symbols);


            interfaceBodies.Add(interfaceBody);
        }

        SymbolCleaner.Operate(Symbols);

        return interfaceBodies;
    }
}

public static class EnumExtracter
{
    public static List<EnumBody> Operate(List<string> Symbols)
    {
        var enumBodies = new List<EnumBody>();
        var indices = KeyWordFinder.FindKeyWords(Symbols, "enum");
        var keyWords = new List<string> {"public"};
        foreach (var index in indices)
        {
            var enumBody = new EnumBody();
            enumBody.name = NameFinder.Operate(index, Symbols);
            enumBody.Modifiers = ModifierFinder.Operate(keyWords, Symbols, index);
            enumBody.Symbols = BodyExtractor.Operate(index, Symbols);
            
            enumBodies.Add(enumBody);
        }

        SymbolCleaner.Operate(Symbols);

        return enumBodies;
    }
}


