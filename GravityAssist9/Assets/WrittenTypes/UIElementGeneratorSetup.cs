using System.Collections.Generic;
using UnityEngine;
public class UIElementGeneratorSetup<Input,Output> : Machine<Input> where Input : MonoBehaviour, IUIPosition where Output : MonoBehaviour,IUIPosition
{
    public int numElements;
    public GameObject prefab;
    public string UIName;
    public Machine<Output> NextMachine;
    public Transform parent;
    public List<Output> output;

    public override void Operate()
    {
        output = new List<Output>();
        for (int i = 0; i < numElements; i++)
        {

            var newGo = GameObject.Instantiate(prefab);
            newGo.transform.SetParent(parent);
            var uiElement = newGo.AddComponent<Output>();
            newGo.name = UIName + " " + i;
            output.Add(uiElement);
        }

    }
    public override void TriggerNextSlaves()
    {
        NextMachine.Trigger(output);
    }


}


