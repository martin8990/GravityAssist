public struct GameNode
{
    public float height;
    public NodeType nodeType;

    public GameNode(float height, NodeType nodeType)
    {
        this.height = height;
        this.nodeType = nodeType;
    }
}


public enum NodeType
{
    free,reserved
}

