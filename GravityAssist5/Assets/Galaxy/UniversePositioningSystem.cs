using Entitas;
using UnityEngine;
[CreateAssetMenu()]
public class UniversePositioningSystem : FlowSystem
{
    public override void MyAction(Contexts contexts)
    {
        var EntitiesWithPos = contexts.universe.GetGroup(UniverseMatcher.Position);
        foreach (var entity in EntitiesWithPos.GetEntities())
        {
            Debug.Log(entity.position.x);
        }
    }
}
