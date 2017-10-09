using Entitas;
public class UniverseLoadSystem : IInitializeSystem
{
    string path;
    public UniverseLoadSystem(string path)
    {
        this.path = path;        
    }
    public void Initialize()
    {
        foreach (var universe in path)
        {
            // Load
        }
    }
}
