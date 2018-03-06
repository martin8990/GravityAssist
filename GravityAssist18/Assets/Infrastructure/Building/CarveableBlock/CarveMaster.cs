using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class CarveMaster : MonoBehaviour
    {
        public int[] smartBlockLayers = new int[] {14,15};
     
        public Vector3Int myMin
        {
            get { return (transform.position - transform.localScale / 2f).ToInt(); }
        }
        public Vector3Int myMax
        {
            get { return (transform.position + transform.localScale / 2f).ToInt(); }
        }

        public List<CarvableBlock> slaves = new List<CarvableBlock>();
        public void OnUpdate()
        {
            foreach (var slave in slaves)
            {
                if (slave!=null)
                {
                    slave.Restore();
                    slave.Carve(myMin, myMax);
                }               
            }
        }
        public void Commit()
        {             
            slaves.Iter((x) => x.Disable());
            slaves.Iter((x) => x.subDivider.childBlocks.Iter((y) => y.gameObject.layer = 15));
            //slaves.Iter((x) => x.subDivider.childBlocks.Iter((y) => y.Commit()));

        }
        private void OnTriggerEnter(Collider other)
        {
            if (enabled)
            {
                for (int i = 0; i < smartBlockLayers.Length; i++)
                {
                    if (other.gameObject.layer == smartBlockLayers[i])
                    {
                        var ohterMaster = other.gameObject.GetComponent<CarveMaster>();
                        var cell = ohterMaster.GetComponent<CarvableBlock>();
                        slaves.Add(cell);
                        //}
                    }
                }
            }            
            
        }
        private void OnTriggerExit(Collider other)
        {
            if (enabled)
            {
                for (int i = 0; i < smartBlockLayers.Length; i++)
                {
                    if (other.gameObject.layer == smartBlockLayers[i])
                    {
                        var otherMaster = other.gameObject.GetComponent<CarveMaster>();
                       
                        var CR = otherMaster.GetComponent<CarvableBlock>();
                        CR.Restore();
                        slaves.Remove(CR);
                    }
                }

            }
        }
    }

}
