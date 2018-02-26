using UnityEngine;
public class MatrixDebugger : MonoBehaviour
{
    public byte height;
    public Vector2Int XR;
    public Vector2Int YR;
    public Vector2Int ZR;


    public BuildingMatrix BuildingMatrix;
    private void Update()
    {
       BuildingMatrix.UpdateRangeHeight(XR,YR,ZR,height); 
    }
}


