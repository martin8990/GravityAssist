using UnityEngine;
[CreateAssetMenu]
public class CreateEntities : FlowSystem
{
    public int numX;
    public override void MyAction(Contexts contexts)
    {
        for (int i = 0; i < numX; i++)
        {
                var entity = contexts.universe.CreateEntity();
                entity.AddPosition(0,0);
            
        }
    }
}
