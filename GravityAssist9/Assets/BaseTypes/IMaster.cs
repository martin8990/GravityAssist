using System.Collections.Generic;
public interface IMaster
{
    void Send<T>(List<T> output);
    List<Slave> Slaves { get; set; }
}



