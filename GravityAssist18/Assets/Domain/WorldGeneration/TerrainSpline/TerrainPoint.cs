using UnityEngine;
using System.Collections.Generic;

namespace Domain
{

    public class TerrainPoint
    {
        public Vector3 Pos;
        public TerrainValue TerrainVal;
        public List<TerrainPoint> Neighbours = new List<TerrainPoint>();
        public Dictionary<TerrainPoint, Vector3> SplineCTRLLookup = new Dictionary<TerrainPoint, Vector3>();


    }
    public struct GPUTerrainPoint
    {
        public Vector3 Pos;
        public int NNeighbours;
        public int StartingIndex;

        public GPUTerrainPoint(Vector3 pos, int nNeighbours, int startingIndex)
        {
            Pos = pos;
            NNeighbours = nNeighbours;
            StartingIndex = startingIndex;
        }
    }

}