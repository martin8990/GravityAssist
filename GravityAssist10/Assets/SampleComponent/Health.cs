using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {

    public void someMethod<T>()
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
public enum SomeEnum
{
    EAST,WEST,NORTH,SOUTH
}

