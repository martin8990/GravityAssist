using System.Reflection;
using System.Linq;
public static class MReflector
{

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



