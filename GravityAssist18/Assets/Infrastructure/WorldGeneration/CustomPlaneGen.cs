//using UnityEngine;
//using UnityEngine.UI;
//using Utility;
//using System.Collections;
//public class CustomPlaneGen : MonoBehaviour
//{
//    public CInt drawDistance;
//    public CInt meshRes;
//    public GameObject[,] planes;
//    public Material planeMaterial;

//    public Text timeText;
//    Vector3[] vertices;
//    void Start()
//    {
//        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
//        sw.Start();

//        planes = ArrayInit.Init2D(drawDistance * 2 + 1, drawDistance * 2 + 1, () => PlaneGen.GeneratePlane(meshRes, planeMaterial));
//        planes.Iter2D((GO) => GO.transform.SetParent(transform));

//        planes.Iteri2D_((x, y, GO) => GO.transform.position = new Vector3((x - drawDistance) * meshRes, 0, (y - drawDistance) * meshRes));
//        planes.Iteri2D_((x, y, GO) => GO.name = "Plane x : " + x + " y : " + y);

//        sw.Stop();
//        Debug.Log("PlaneGen took " + sw.Elapsed.TotalMilliseconds + " ms");


//        vertices = new Vector3[meshRes * meshRes];
//        for (int z = 0; z < meshRes; z++)
//        {
//            // [ -size / 2, size / 2 ]
//            float zPos = ((float)z / (meshRes - 1) - .5f) * meshRes;
//            for (int x = 0; x < meshRes; x++)
//            {
//                // [ -size / 2, size / 2 ]
//                float xPos = ((float)x / (meshRes - 1) - .5f) * meshRes;
//                vertices[x + z * meshRes] = new Vector3(xPos, 0f, zPos);
//            }
//        }
//    //    StartCoroutine(UpdateMesh());
//    }
//    //public IEnumerator UpdateMesh()
//    //{
//    //    int l = planes.GetLength(0);
//    //    for (int x = 0; x < l; x++)
//    //    {
//    //        for (int y = 0; y < l; y++)
//    //        {
//    //            PlaneGen.UpdatePlane(vertices, planes[x, y]);
//    //            yield return null;
//    //        }
//    //    }
//    //    StartCoroutine(UpdateMesh());
//    //}
//}