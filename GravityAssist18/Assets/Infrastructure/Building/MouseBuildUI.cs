using UnityEngine;
using Utility;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

namespace Infrastructure
{
    public class MouseBuildUI : MonoBehaviour
    {
        enum Mode {Foundation,Floor,Wall}
        Mode mode = Mode.Foundation;
        public LayerMask editMask;

        [HideInInspector]
        public UnityEvent newBlock;
        [HideInInspector]
        public UnityEvent stopped;
        [HideInInspector]
        public UnityEvent completed;
        
        
        public FoundationBuilder foundationBuilder;
                
        Camera cam;
        Vector3 p1;
        Vector3 p2;
        bool Dragging;

        void Start()
        {
            cam = Camera.main;
        }
  

        public void OnUpdate(CarvableBlock curBlock)
        {
            var pos = Snap.GetSnappedPos(cam, Vector3.one, ~editMask);
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
                Dragging = false;
                stopped.Invoke();
            }

            p2 = pos;
            curBlock.OnUpdate();
            switch (mode)
            {
                case Mode.Foundation:
                    foundationBuilder.TransfromBlock(p1, p2, curBlock);
                    
                    break;
                case Mode.Floor:
                    break;
                case Mode.Wall:
                    break;
                default:
                    break;
            }

            if (Input.GetMouseButtonUp(0))
            {
                Dragging = false;
                if (curBlock.valid)
                {
                    //var historyEl = new AddedGameObject(curBlock.gameObject);
                    //historyManager.AddElement(historyEl);
                    completed.Invoke();
                    
                }
                else
                {
                    Destroy(curBlock.gameObject);
                }
                newBlock.Invoke();
                //curBlock = null;

            }


           
        }
             


    }
}
