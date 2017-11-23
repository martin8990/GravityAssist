using System.Collections.Generic;
using System.Linq;
[System.Serializable]
public class AssemblyBoi : Address
{
    public List<TypeBoi> typeBois;
    public List<AssemblyBoi> subAssemblies = new List<AssemblyBoi>();

    public override List<Address> GetSubAdresses()
    {
        var adresses = new List<Address>();
        foreach (var adress in subAssemblies)
        {
            adresses.Add(adress);
        }

        return adresses;
    }
}

public abstract class Address
{
    public string name;
    public abstract List<Address> GetSubAdresses();

}

    
