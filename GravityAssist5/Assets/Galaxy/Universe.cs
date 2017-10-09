using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


public class Universe : MonoBehaviour {

    Contexts contexts;
    public FlowSystem flowSystem;

    void Start()
    {
        contexts = Contexts.sharedInstance;
        flowSystem.Execute(contexts);
    }


}
