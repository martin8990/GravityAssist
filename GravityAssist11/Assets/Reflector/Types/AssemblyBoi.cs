using System.Collections.Generic;
[System.Serializable]
public class AssemblyBoi
{
    public string name;
    public List<TypeBoi> typeBois;
    public List<AssemblyBoi> subAssemblies = new List<AssemblyBoi>();

}
