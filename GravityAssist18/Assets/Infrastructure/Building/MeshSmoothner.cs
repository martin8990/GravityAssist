using UnityEngine;
using Utility;

public class MeshSmoothner : MonoBehaviour
{
    float height;

    Camera cam;
    Vector2Int planeId1;
    Vector2Int coord1;

    Vector2Int p2;
    bool Dragging;
    public CInt meshRes;



    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        var pos = Snap.GetSnappedPos(cam, Vector3.one);
        if (Input.GetMouseButton(0))
        {
            if (!Dragging)
            {
                planeId1 = new Vector2Int((int)pos.x / meshRes, (int)pos.z / meshRes);
                coord1 = new Vector2Int((int)pos.x % meshRes,(int)pos.z%meshRes);
                
                Dragging = true;
            }
            if (Dragging)
            {
             //   p2 = pos;

                
            }
        }
    }
}



