using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestDriver : MonoBehaviour {

    public MType mType;
    public void MTrigger()
    {
      mType =  OutputTypeExtracter.GetOutputType(typeof(TopClass), 5);
    }

}

public class TopClass
{
    public MiddleClass middleClass;

}

public class MiddleClass
{
    public BottomClass bottomClass;

}

public class BottomClass
{

}
