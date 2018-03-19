using UnityEngine;
using System.Collections;
using Utility;

namespace Infrastructure
{
    public class AddedBlock : PastEvent
    {
        public CarvableBlock fluidCell;
        public AddedBlock(CarvableBlock obj)
        {

            this.fluidCell = obj;
        }

        public override IEnumerator Redo()
        {
            
            fluidCell.Restore();
            yield return null;

//            fluidCell.carveMaster.Commit();
        }

        public override void CleanUp()
        {

        }
            //Destroy GameObject

        public override IEnumerator Undo()
        {
            Debug.Log("Undoing");
            fluidCell.Disable();       
            fluidCell.GetComponent<CarveMaster>().slaves.Iter((x) => x.Restore());// If not just disabled ?   
            
            yield return null;
            //fluidCell.Commit();
        }
    }

  


}
