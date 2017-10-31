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
        typeDatabase.AssemblyBois.Clear();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            var aBoi = new AssemblyBoi();
            aBoi.typeBois = TypeCollecter.GetTypes(assembly);
            aBoi.name = assembly.GetName().Name;
            typeDatabase.AssemblyBois.Add(aBoi);            
        }
        
    }
    public void Start()
    {
      //  MachineButtonsGenerator.GenerateMachineButtons(ButtonPF,MachinePF, MachineButtonPanel,Grid, typeDatabase.typeBois);
    }

}

