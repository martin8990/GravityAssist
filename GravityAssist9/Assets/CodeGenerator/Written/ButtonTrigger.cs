using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger<T> : MonoBehaviour,ITrigger {
    public Machine<T> slave;
    public Button button;
    public List<T> Data;
    public void Start()
    {
        if (button==null)
        {
            button = gameObject.GetComponent<Button>();
        }
        button.onClick.AddListener(() => slave.Trigger(Data));
        
    }

}
