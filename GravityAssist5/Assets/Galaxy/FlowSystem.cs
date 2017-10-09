using UnityEngine;
public abstract class FlowSystem : ScriptableObject
{
    public FlowSystem nextSystem;
    public void Execute(Contexts contexts)
    {
        MyAction(contexts);
        if (nextSystem!=null)
        {
            nextSystem.Execute(contexts);
        }
    }
    public abstract void MyAction(Contexts contexts);
    
    
}
