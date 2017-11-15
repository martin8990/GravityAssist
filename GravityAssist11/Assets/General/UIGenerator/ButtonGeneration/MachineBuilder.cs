using UnityEngine;
public static class MachineBuilder
{

    //public static GameObject BuildMachine(GameObject MachinePF,GameObject IOPF, Transform GridTF, MachineStrings machineStrings)
    //{
    //    var machine = GameObject.Instantiate(MachinePF, GridTF);
    //    var machineInput = machine.GetComponent<MachineInput>();
    //    var machineInputs = GOMassInstantiator.MassInstantiate(IOPF,machineInput.InputTF, machineStrings.parameters.Count);
    //    var rectTFs = ComponentsGetter<RectTransform>.GetFromGOS(machineInputs);
    //    UIPositioner.PositionVertically(machineInput.InputTF, rectTFs);

    //    if (machineStrings.returnType.Type != "void")
    //    {
    //        var Output = GameObject.Instantiate(IOPF);
    //        Output.transform.SetParent(machineInput.OutputTF,false);
    //    }

    //    machineInput.nameLabel.text = machineStrings.Name; 
        

    //    return machine;
    //}
}


