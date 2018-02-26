using System.Collections.Generic;
using UnityEngine;
public class FaceManager : MonoBehaviour
{
    public GameObject facePrefab;
    public List<GameObject> faces = new List<GameObject>();
    GameObject curFace= null;
    public void BuildFace(Dim dim,bool inverse, Vector3 pos, float scale, int cnt)
    {
        if (cnt>=faces.Count)
        {
            curFace = GameObject.Instantiate(facePrefab,transform);
            faces.Add(curFace);
        }
        else
        {
            curFace = faces[cnt];
        }
        curFace.transform.position = pos;
        
        switch (dim)
        {   
            case Dim.X:
                curFace.transform.localScale = new Vector3(scale / transform.localScale.x, 1, 1);
                if (!inverse)
                {
                    curFace.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    curFace.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                break;
            case Dim.Z:
                curFace.transform.localScale = new Vector3(scale / transform.localScale.z, 1, 1);
                if (!inverse)
                {
                    curFace.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                else
                {
                    curFace.transform.rotation = Quaternion.Euler(0, 270, 0);
                }
                break;
        }
        
    }
    public void PurgeTheRest(int cnt)
    {
        for (int i = faces.Count - 1; i >= cnt; i--)
        {
            faces.RemoveAt(i);
        }
    }

}

public enum Dim
{
    X,Z
}



