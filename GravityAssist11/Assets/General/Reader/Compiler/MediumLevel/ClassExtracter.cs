using System.Collections.Generic;
using UnityEngine;

public static class ClassExtracter
{
    public static List<ClassBody> Operate(List<string> Symbols)
    {
        var classBodies = new List<ClassBody>();
        var indices = KeyWordFinder.FindKeyWords(Symbols, "class");
        var keyWords = new List<string> { "partial", "abstract", "private", "static", "public", "internal", "protected", "unsafe" };
        foreach (var index in indices)
        {
            var classBody = new ClassBody();
            classBody.name = NameFinder.Operate(index, Symbols);
            classBody.Generics = GenericsFinder.Operate(index, Symbols);
            classBody.Ancestors = AnsestorExtracter.operate(index, Symbols);
            classBody.Modifiers = ModifierFinder.Operate(keyWords, Symbols, index);
            classBody.Symbols = BodyExtractor.Operate(index, Symbols);
            classBody.atributeBodies = AtributeExtracter.Operate(Symbols, index);

            classBody.classBodies = ClassExtracter.Operate(classBody.Symbols);
            classBody.stuctBodies = StructExtracter.Operate(classBody.Symbols);



            var subBodies = SubBodyFinder.ExtractSubBodies(classBody.Symbols);
            classBody.methodBodies = MethodExtracter.Operate(classBody.Symbols, subBodies);
            classBody.propertyBodies = PropertyExtractor.Operate(subBodies, classBody.Symbols);
          
            classBodies.Add(classBody);

        }

        SymbolCleaner.Operate(Symbols);


        return classBodies;
    }
}



[System.Serializable]
public class VariableBody
{

}

