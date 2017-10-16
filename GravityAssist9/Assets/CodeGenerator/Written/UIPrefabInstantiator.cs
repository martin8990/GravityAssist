using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrefabInstantiator<Input,Output> : Machine<Input,Output> where Input : IPrefab where Output : MonoBehaviour,IUIPosition
{
    public List<Output> output;
  
    public override List<Output> Operate(List<Input> input)
    {
        output = new List<Output>();
        for (int i = 0; i < input.Count; i++)
        {
            var newUiGameObject = GameObject.Instantiate(input[i].Prefab);
            newUiGameObject.transform.SetParent(input[i].Parent, false);

            var SomeComponent = newUiGameObject.GetComponent<Output>();
            output.Add(SomeComponent);
        }
        return output;
    }
}
