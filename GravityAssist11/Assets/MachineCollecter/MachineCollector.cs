using System.Collections.Generic;
using UnityEngine;

public static class MachineCollector
{
    [Machine(name ="GetMachineStrings",machineCategory = MachineCategory.MachineCollecter)]
    public static List<MachineStrings> GetMachineStrings()
    {
        var Machines = MachineMethodFinder.GetMethods();
        foreach (var machine in Machines)
        {
            Debug.Log(machine.Name);
        }
        return null;
    }
}
