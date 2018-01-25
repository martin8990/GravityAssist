using System.Collections.Generic;
using UnityEngine;
using Utility;

[System.Serializable]
public class Workspace
{
    public bool Reserved = false;
    public Vector3 Position;

    public Workspace(Vector3 position)
    {
        Position = position;
    }
    public static Workspace GetClosestWorkSpace(List<Workspace> workspaces, Vector3 myPos)
    {
        float mindist = 1e14f;
        Workspace bestSpace = null;
        foreach (var workspace in workspaces)
        {
            if (workspace.Reserved == false)
            {
                var dist = myPos.SquareDist2(workspace.Position);
                if (dist < mindist)
                {
                    bestSpace = workspace;
                    mindist = dist;
                }
            }
        }
        if (bestSpace!=null)
        {
            
            bestSpace.Reserved = true;
        }
        return bestSpace;
    }
}

