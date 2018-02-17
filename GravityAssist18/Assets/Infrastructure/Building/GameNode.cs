public struct GameNode
{
    public int height;
    public NodeType nodeType;

    public GameNode(int height,NodeType nodeType) : this()
    {
        this.height = height;
        this.nodeType = nodeType;
        
    }
}


public enum NodeType
{
    Terrain,
    Workpos,
    BuildPos,
    Floor,
    Wall,


}

