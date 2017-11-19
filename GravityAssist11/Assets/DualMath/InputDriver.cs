using System;
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
        var result = inputField.text.Split(new[] { '\r', '\n' });
        int ChangeIndex = inputField.caretPosition;
        int LineNumber = 0;
        for (int i = 0; i < result.Length; i++)
        {
            ChangeIndex -= result[i].Length+1;
            if (ChangeIndex<=0)
            {
                LineNumber = i;
            }
            
        }
        if (LineNumber<result.Length)
        {
            MathCommander.ProcessLine(result[LineNumber], LineNumber);
        }
    }


}
