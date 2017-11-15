using System.Collections.Generic;
public static class PropertyExtractor
{
    public static List<PropertyBody> Operate(List<int> subBodies,List<string> symbols)
    {
        var Ids = PropertyIdFinder.Operate(subBodies, symbols);
        var Properties = new List<PropertyBody>();
        var modifiers = new List<string> { "public", "private", "protected" };
        foreach (var id in Ids)
        {
            var prop = new PropertyBody();
            prop.name = NameFinder.Operate(id - 2, symbols);
            prop.type = NameFinder.Operate(id - 3, symbols);
            prop.symbols = BodyExtractor.Operate(id, symbols);
            prop.modifiers = ModifierFinder.Operate(modifiers, symbols, id);
            Properties.Add(prop);
        }
        return Properties;
    }
}
