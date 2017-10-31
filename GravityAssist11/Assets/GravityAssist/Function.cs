using System.Collections;
using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Method)]
public class Machine : Attribute {

    public MachineCategory machineCategory { get; set; }
}
public enum MachineCategory
{
    Default, MachineCollecter
}
