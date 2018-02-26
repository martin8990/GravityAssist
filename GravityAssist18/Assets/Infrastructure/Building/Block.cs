using UnityEngine;



namespace Infrastructure
{

    public abstract class Block : MonoBehaviour
    {
        public float cost;
        public bool valid;

        public abstract void TransformBlock(Vector3 p1, Vector3 p2);
        public abstract void CompleteBlock();
      

    }

    //public class PlanningBlock : MonoBehaviour
    //{
    //    public bool Valid;
    //    public float Cost;
    //    public LayerMask planningLayer;
    //    public Material mat;
    //    public float[] groundDistances = new float[4];

    //    private void Start()
    //    {
    //        mat = GetComponent<MeshRenderer>().material;
    //    }

    //    public void UpdatePlanning()
    //    {
    //        Vector3[] startPos = new Vector3[4];
    //        var p = transform.position;
    //        var s = transform.localScale/2;
    //        startPos[0] = p + new Vector3(s.x,0,s.z);
    //        startPos[1] = p + new Vector3(-s.x, 0, s.z);
    //        startPos[2] = p + new Vector3(s.x, 0, -s.z);
    //        startPos[3] = p + new Vector3(-s.x, 0, -s.z);

    //        float[] dHeights = new float[4];


    //        for (int i = 0; i < startPos.Length; i++)
    //        {
    //            RaycastHit hit;
    //            if (Physics.Raycast(startPos[i],Vector3.down,out hit,20,~planningLayer))
    //            {

    //                dHeights[i] = startPos[i].y - hit.point.y;   
    //            }
    //        }
    //        if (isValid(dHeights))
    //        {
    //            Valid = true;
    //            Cost = 0;
    //            transform.position = new Vector3(p.x, p.y - Mathf.Max(dHeights) / 2, p.z);
    //            transform.localScale = new Vector3(s.x * 2, Mathf.Max(dHeights), s.z * 2);
    //            for (int i = 0; i < dHeights.Length; i++)
    //            {
    //                Cost += dHeights[i];
    //            }
    //            mat.color = Color.green;

    //        }
    //        else
    //        {
    //            Valid = false;
    //            mat.color = Color.red;
    //        }



    //    }

    //    bool isValid(float[] dheights)
    //    {
    //        for (int x = 0; x < dheights.Length; x++)
    //        {
    //            if (dheights[x] == 0)
    //            {
    //                return false;
    //            }
    //        }
    //        return true;
    //    }

    //}
}
