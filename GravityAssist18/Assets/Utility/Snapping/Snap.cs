using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Utility
{
    public static class Snap
    {
        public static Vector3 GetSnappedPos(Camera cam, Vector3 scale)
        {
            var pos = MousePositioning.MouseToWorldPos(cam);
            var posRound = new Vector3(
                Mathf.Round(pos.x - scale.x / 2f) + scale.x / 2f,
                Mathf.Round(pos.y),
                Mathf.Round(pos.z - scale.z / 2f) +scale.z / 2f);
            return posRound;
        }
        public static Vector3 GetSnappedPos(Camera cam, Vector3 scale,LayerMask layerMask)
        {
            var pos = MousePositioning.MouseToWorldPos(cam,layerMask);
            var posRound = new Vector3(
                Mathf.Round(pos.x) + 0.5f,
                Mathf.Round(pos.y),
                Mathf.Round(pos.z ) + 0.5f);
            return posRound;
        }

        public static Vector3Int ToInt(this Vector3 v3)
        {
            return new Vector3Int((int)v3.x, (int)v3.y, (int)v3.z);
        }
    }
}
