using System.Collections.Generic;
public static class ClassExtracter
{
    public static List<ClassBody> Operate(List<string> Symbols)
    {
        var classBodies = new List<ClassBody>();
        var indices = KeyWordFinder.FindKeyWords(Symbols, "class");
        var keyWords = new List<string> { "partial", "abstract", "private", "static", "public", "internal", "protected" };
        foreach (var index in indices)
        {
            var classBody = new ClassBody();
            classBody.name = NameFinder.Operate(index, Symbols);
            classBody.Symbols = BodyGetter.Operate(index, Symbols);
            classBody.Generics = GenericsFinder.Operate(index, Symbols);
            classBody.Interfaces = InterfaceFinder.operate(index, Symbols);
            classBody.Modifiers = ModifierFinder.Operate(keyWords, Symbols, index);



            classBodies.Add(classBody);
        }

        SymbolCleaner.Operate(Symbols);

        return classBodies;
    }
}


