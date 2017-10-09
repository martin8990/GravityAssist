using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class Operation : FlowSystem
{
    public List<string> componentNames;
    
    public override void MyAction(Contexts contexts)
    {
        foreach (var name in componentNames)
        {
            contexts.universe.GetGroup()
        }

        throw new System.NotImplementedException();
    }
}
