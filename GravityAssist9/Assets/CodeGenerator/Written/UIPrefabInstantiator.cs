using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrefabInstantiator<Input,Output> : Machine<Input> where Input : IPrefab where Output : MonoBehaviour,IUIPosition
{
    public Machine<Output> nextSlave;
    public List<Output> output;
    
    public override void Operate()
    {
        output = new List<Output>();
        for (int i = 0; i < myData.Count; i++)
        {
            var newUiGameObject = GameObject.Instantiate(myData[i].Prefab);
            newUiGameObject.transform.SetParent(myData[i].Parent, false);

            var SomeComponent = newUiGameObject.GetComponent<Output>();
            output.Add(SomeComponent);
        }        
    }

    public override void TriggerNextSlaves()
    {
        nextSlave.Trigger(output);
    }
}
