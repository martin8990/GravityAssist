using UnityEngine;
using System.Collections;
namespace Infrastructure
{
    public class TransformedBlock : PastEvent
    {
        public CarvableBlock cell;
        public Vector3 previousPosition;
        public Vector3 previousScale;

        public Vector3 curPosition;
        public Vector3 curScale;

        public TransformedBlock(CarvableBlock cell, Vector3 previousPosition, Vector3 previousScale, Vector3 curPosition, Vector3 curScale)
        {
            this.cell = cell;
            this.previousPosition = previousPosition;
            this.previousScale = previousScale;
            this.curPosition = curPosition;
            this.curScale = curScale;
        }

        public override IEnumerator Redo()
        {
            // Must run in fixed update
            
            cell.transform.position = curPosition;
            cell.transform.localScale = curScale;
            yield return new WaitForFixedUpdate();

            cell.Commit();
        }

        public override void CleanUp()
        {
            //Destroy GameObject
        }

        public override IEnumerator Undo()
        {
            
            cell.transform.position = previousPosition;
            cell.transform.localScale = previousScale;
            yield return new WaitForFixedUpdate();
           
            cell.Commit();
        }
    }

  


}
