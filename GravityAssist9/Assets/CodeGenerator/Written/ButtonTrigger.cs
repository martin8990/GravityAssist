using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger<T> : InputBehaviour<T> {
    public Button button;
    public void Start()
    {
        if (button==null)
        {
            button = gameObject.GetComponent<Button>();
        }
        button.onClick.AddListener(() => Input());
        
    }

}
