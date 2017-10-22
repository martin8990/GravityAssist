using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy
{
    int hitpoints;
    public int Hitpoints
    {
        get { return hitpoints; }
        set { hitpoints = value; }
    }
    public void Hit(int damage)
    {
        hitpoints -= damage;
    }
}

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

