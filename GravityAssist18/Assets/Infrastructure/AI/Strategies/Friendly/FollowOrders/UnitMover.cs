using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    [RequireComponent(typeof(UnitMover))]
    public class MainAIUI : MonoBehaviour
    {
        public List<AIUnit> selected = new List<AIUnit>();
        private void Update()
        {
            var pos = MousePositioning.MouseToWorldPos(cam, ~boxMask);
            if (!Dragging)
            {
                p1 = pos;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Dragging = true;
            }
            if (Input.GetMouseButtonDown(1))
            {

            }
            p2 = pos;


            if (Input.GetMouseButtonUp(0))
            {

            }

        }
    }
    
    public class UnitMover : MonoBehaviour
    {
        public UnitSelector unitSelector;
        public void OnUpdate(List<AIUnit> selected)
        {
            if (Input.GetMouseButtonDown(1))
            {

            }
        }
    }

}


