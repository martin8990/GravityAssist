using System.Reflection;
using System.Linq;
public static class MachineMethodFinder
{
    [Machine(machineCategory = MachineCategory.MachineCollecter,name = "GetMethods")]
    public static MethodInfo[] GetMethods()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var methods =  assembly.GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(Machine), false).Length > 0)
                      .ToArray();
        return methods;
    }
}
