using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputDriver : MonoBehaviour {
    public InputField inputField;

    public void Start()
    {
        inputField.ActivateInputField();
    }

    public void OnEdit()
    {
        Debug.Log(inputField.text);
    }


}
