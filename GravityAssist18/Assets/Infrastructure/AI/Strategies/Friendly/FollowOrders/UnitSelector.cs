using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{


    public class UnitSelector : MonoBehaviour
    {
        public Triggerer SelectionBoxPrefab;
        Triggerer curBox;
        Vector3 p1;
        Vector3 p2;
        bool Dragging;
        public Camera cam;
        public List<AIUnit> selected = new List<AIUnit>();
        public LayerMask boxMask;
        public void OnFirstClick(Vector3 _p1)
        {
            p1 = _p1;
            curBox = Instantiate(SelectionBoxPrefab, transform);
        }
        public void OnDrag(Vector3 p2)
        {
            int height = 100;
            var minPos = (new Vector3(Mathf.Min(p1.x, p2.x), Mathf.Ceil(Mathf.Min(p1.y, p2.y)), Mathf.Min(p1.z, p2.z))).ToInt();
            var maxPos = (new Vector3(Mathf.Max(p1.x, p2.x), Mathf.Max(p1.y, p2.y), Mathf.Max(p1.z, p2.z)) + Vector3.one).ToInt();
            maxPos = new Vector3Int(maxPos.x, minPos.y + height, maxPos.z);

            curBox.transform.position = new Vector3(minPos.x + maxPos.x, minPos.y + maxPos.y, minPos.z + maxPos.z) / 2f;
            curBox.transform.localScale = maxPos - minPos;

        }
        public void OnUp()
        {
            Dragging = false;
            enabled = false;
            selected = new List<AIUnit>();
            for (int i = 0; i < curBox.TriggeredObjects.Count; i++)
            {
                selected.Add(curBox.TriggeredObjects[i].GetComponent<AIUnit>());
            }
            Destroy(curBox.gameObject);
        }
        public void OnCancel()
        {
            Destroy(curBox.gameObject);
        }

    }

}


