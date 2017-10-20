﻿using System.Collections.Generic;
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
            newMethodBody.Generics = GenericsFinder.Operate(id-7, symbols);
            newMethodBody.modifiers = ModifierFinder.Operate(mods, symbols, id);
            newMethodBody.symbols = BodyExtractor.Operate(id, symbols);
            mBodies.Add(newMethodBody);
        }
        return mBodies;
    }
}

