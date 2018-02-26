using UnityEngine;
using Utility;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Infrastructure
{
    public class BuildPlanner : MonoBehaviour
    {

        public LayerMask blockMask;
        public Text costText;
        public int index;
        public SmartBlock smartBlockPrefab;

        public int dHeight;
        Camera cam;
        SmartBlock curBlock;
        Vector3 p1;
        Vector3 p2;

        bool Dragging;
        int priority = int.MaxValue;
        void Start()
        {
            cam = Camera.main;
        }
        void OnEnable()
        {
            curBlock = GameObject.Instantiate(smartBlockPrefab, transform);
            curBlock.Priority = priority;
            priority--;
        }

        void Update()
        {
            var pos = Snap.GetSnappedPos(cam, Vector3.one, ~blockMask);
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
                Destroy(curBlock.gameObject);
                this.enabled = false;
            }

            p2 = pos + Vector3.up*dHeight + Vector3.one;
            curBlock.transform.position = 0.5f*(p1 + p2);
            curBlock.transform.localScale = 
                new Vector3(Mathf.Abs(p2.x - p1.x),Mathf.Abs(p2.y-p1.y),Mathf.Abs(p2.z-p1.z));

            costText.text = "Calculate Cost";

            if (Input.GetMouseButtonUp(0))
            {
                Dragging = false;
                    OnEnable();

            }

        }

        public void SetBlock(int id)
        {

            enabled = true;
        }
    }
}
