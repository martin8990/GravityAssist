//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public static class MachineButtonsGenerator
//{
//    public static List<GameObject> GenerateMachineButtons(GameObject ButtonPF,GameObject MachinePF, Transform parent,Transform GridTF , List<MachineStrings> machines)
//    {
//        var GOS = UIGenerator.GenerateUI(ButtonPF, parent, machines.Count, UILayout.Vertical);
//        for (int i = 0; i < GOS.Count; i++)
//        {
//            var machine = machines[i];
//            GOS[i].GetComponentInChildren<Text>().text = machine.Name;
//            var trigger = GOS[i].GetComponent<MachineBuildTrigger>();
//            trigger.GridTF = GridTF;
//            trigger.MachinePF = MachinePF;
//            trigger.machineStrings = machines[i];
//        }
//        return GOS;
//    }

//}
