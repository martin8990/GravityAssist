using System.Collections.Generic;
public static class AtributeExtracter
{
    public static List<AtributeBody> Operate(List<string> symbols,int index)
    {
        var attributes = new List<AtributeBody>();
        var atributeBodies = AtributeBodyExtractor.Operate(symbols, index);
        foreach (var ab in atributeBodies)
        {
            var attribute = new AtributeBody();
            attribute.Arguments = ArgumentExtracter.GetWithoutType(ab, ab.Count-1);
            attribute.Addres = AddresFinder.Operate(ab,0);
           
            attributes.Add(attribute);
        }
        return attributes;
       
    
    }
}

