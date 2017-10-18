using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public void someMethod()
    {
        if (true)
        {
            Debug.Log("Yow");
        }
    }
}

public struct SampleGenericStruct<T> : SampleInterface<T>
{
    public float SampleFloat;
}

public interface SampleInterface<T>
{

}


