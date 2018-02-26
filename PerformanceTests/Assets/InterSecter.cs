using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
using Utility;

public class InterSecter : MonoBehaviour {

    public Material mat;

    public List<Transform> Cubes;
    List<Vector2Int> horPos;
    List<Vector2Int> verPos;
    List<int> horDist;
    List<int> verDist;
    List<bool> horReversed;
    List<bool> verReversed;

    int res;
    Vector2Int[,] interSections;
    public Mesh faceMesh;
    public GameObject upperQuad;
    public GPUFaceInstancer faceInstancer;
    bool UpdateFaces;
    public FaceManager faceManager;

    private void Start()
    {
        
        Cubes.Add(transform);
    }

    void Update()
    {
        InterpretVectors();
        RedrawFaces();
    }

    void InterpretVectors()
    {
        horPos = new List<Vector2Int>();
        verPos = new List<Vector2Int>();
        horDist = new List<int>();
        verDist = new List<int>();
        horReversed = new List<bool>();
        verReversed = new List<bool>();

        foreach (var tf in Cubes)
        {
            var p = tf.position;
            var s = tf.localScale;

            horPos.Add(new Vector2Int((int)(p.x - s.x / 2f), (int)(p.z - s.z / 2f)));
            horPos.Add(new Vector2Int((int)(p.x - s.x / 2f), (int)(p.z + s.z / 2f)));

            horDist.Add((int)s.x);
            horDist.Add((int)s.x);
            horReversed.Add(false);
            horReversed.Add(true);

            verPos.Add(new Vector2Int((int)(p.x - s.x / 2f), (int)(p.z - s.z / 2f)));
            verPos.Add(new Vector2Int((int)(p.x + s.x / 2f), (int)(p.z - s.z / 2f)));
            verDist.Add((int)s.z);
            verDist.Add((int)s.z);

            verReversed.Add(false);
            verReversed.Add(true);

        }
    }

    void RedrawFaces()
    {
        
        FindIntersections();
        int cnt = 0;
        for (int i = 0; i < horPos.Count; i++)
        {
            bool inFace = false;
            Vector2Int startPos = Vector2Int.zero;
            for (int j = 0; j < verPos.Count; j++)
            {
                if (interSections[i, j] != Vector2Int.zero)
                {
                    if (!inFace)
                    {
                        startPos = interSections[i, j];
                        inFace = true;
                    }
                    else
                    {

                        var endPos = interSections[i, j];
                        var pos = new Vector3((startPos.x + endPos.x) / 2f, 0.5f, startPos.y);
                        faceManager.BuildFace(Dim.X, horReversed[i], pos, (endPos.x - startPos.x),cnt);
                        inFace = false;
                        cnt++;
                    }
                }

            }
        }
        for (int i = 0; i < verPos.Count; i++)
        {
            bool inFace = false;
            Vector2Int startPos = Vector2Int.zero;
            for (int j = 0; j < horPos.Count; j++)
            {
                if (interSections[j, i] != Vector2Int.zero)
                {
                    if (!inFace)
                    {
                        startPos = interSections[j, i];
                        inFace = true;
                    }
                    else
                    {

                        var endPos = interSections[j, i];

                        
                        var pos = new Vector3((startPos.x), 0.5f, (startPos.y + endPos.y) / 2f);
                        faceManager.BuildFace(Dim.Z, verReversed[i], pos, (endPos.y - startPos.y), cnt);
                        cnt++;                        
                        inFace = false;
                    }
                }

            }
        }



    }

    private void FindIntersections()
    {
        interSections = new Vector2Int[horPos.Count, verPos.Count];
        for (int i = 0; i < horPos.Count; i++)
        {
            for (int j = 0; j < verPos.Count; j++)
            {
                if (horDist[i] >= verPos[j].x - horPos[i].x
                    && verDist[i] >= horPos[i].y - verPos[j].y
                    && horPos[i].x <= verPos[i].x
                    && verPos[i].y <= horPos[i].y) // is there an intersection?
                {
                    interSections[i, j] = new Vector2Int(verPos[j].x, horPos[i].y); // Using geometric property
                }
                else
                {
                    interSections[i, j] = Vector2Int.zero;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i < horPos.Count; i++)
        {
            Gizmos.DrawSphere(new Vector3(horPos[i].x, 0.5f, horPos[i].y), 0.1f);
            Gizmos.DrawSphere(new Vector3(horPos[i].x + horDist[i], 0.5f, horPos[i].y), .1f);

        }
        Gizmos.color = Color.cyan;

        for (int i = 0; i < horPos.Count; i++)
        {
            Gizmos.DrawSphere(new Vector3(verPos[i].x, 0.5f, verPos[i].y), 0.1f);
            Gizmos.DrawSphere(new Vector3(verPos[i].x, 0.5f, verPos[i].y + verDist[i]), .1f);

        }

        Gizmos.color = Color.red;
        for (int x = 0; x < interSections.GetLength(0); x++)
        {
            for (int z = 0; z < interSections.GetLength(1); z++)
            {
                Gizmos.DrawSphere(new Vector3(interSections[x, z].x, 0.5f, interSections[x, z].y), .1f);
            }
        }
    }




}


