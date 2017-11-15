using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;



public class TestDriver : MonoBehaviour {
    
    public AssemblyDB typeDatabase;

    public GameObject ButtonPF;
    public GameObject MachinePF;

    public Transform MachineButtonPanel;
    public Transform Grid;

    public void Reload()
    {
        Reflector.getAssemblies(typeDatabase.AssemblyBois);
        
    }
    public void Start()
    {
      //  MachineButtonsGenerator.GenerateMachineButtons(ButtonPF,MachinePF, MachineButtonPanel,Grid, typeDatabase.typeBois);
    }

}


