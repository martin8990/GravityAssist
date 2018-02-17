using UnityEngine;
using System.Collections.Generic;
using Utility;
namespace Infrastructure
{
    public class WorkSpaceBuilder : MonoBehaviour
    {
        public List<Workspace> workspaces = new List<Workspace>();

        public bool AllWorkspacesOccupied()
        {
            bool klopt = true;
            foreach (var ws in workspaces)
            {
                if (ws.Reserved == false)
                {
                    klopt = false;
                }
            }
            return klopt;
        }
        private void Start()
        {
            UpdatePositions();
        }
        public void UpdatePositions()
        {
            workspaces = new List<Workspace>();
            int xW = Mathf.FloorToInt(transform.localScale.x);
            int yW = Mathf.FloorToInt(transform.localScale.z);

            int nXPos = 2;
            int nYPos = 2;
            if (xW==1)
            {
                nXPos = 1;
            }
            if (yW == 1)
            {
                nYPos = 1;
            }
            for (int x = 0; x <= nXPos; x++)
            {
                for (int y = 0; y <= nYPos; y++)
                {
                    float mx = -xW / 2 + xW / nXPos * (x+0.5f);
                    //float xHigh = -xW / 2 + xW / nXPos * (x+1);
                    
                    float my = -yW / 2 + yW / nYPos * (y+0.5f);
                    Vector2Int myId = new Vector2Int((int)transform.position.x + (int)mx, (int)transform.position.z + (int)my);
                    workspaces.Add(new Workspace(new Vector3(mx, 0, my) + transform.position));
                                        
                }
            } 


            //for (int x = 0; x < xW; x++)
            //{
            //    float xPos = x - xW / 2f + 1/2f;
            //    float yPos = yW/2f + 1/2f;
            //    workspaces.Add(new Workspace( new Vector3(xPos, 0, yPos) + transform.position));
            //    workspaces.Add(new Workspace( new Vector3(xPos, 0, -yPos) + transform.position));

            //}
            //for (int y = 0; y < yW; y++)
            //{
            //    float yPos = y - yW / 2f + 1 / 2f;
            //    float xPos = xW / 2f + 1 / 2f;
            //    workspaces.Add(new Workspace(new Vector3(xPos, 0, yPos) + transform.position));
            //    workspaces.Add(new Workspace(new Vector3(-xPos, 0, yPos) + transform.position));
            //}



        }

        private void OnDrawGizmosSelected()
        {
            foreach (var ws in workspaces)
            {
                if (ws.Reserved)
                {
                    Gizmos.color = Color.red;

                }
                else
                {
                    Gizmos.color = Color.green;
                }
                Gizmos.DrawCube(ws.Position, Vector3.one);
            }
            workspaces.Iter((x) => Gizmos.DrawCube(x.Position, Vector3.one));
        }
    }
}

