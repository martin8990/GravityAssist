using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Slave: ScriptableObject
{
    public abstract void Recieve<Input>(List<Input> input);
}



