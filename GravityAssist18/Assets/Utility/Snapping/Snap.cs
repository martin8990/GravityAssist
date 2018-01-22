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
    }
}
