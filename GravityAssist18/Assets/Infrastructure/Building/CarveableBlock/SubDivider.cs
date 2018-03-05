using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class SubDivider : MonoBehaviour
    {
        [NonSerialized]
        public CarvableBlock SmartBlockPF;
        [NonSerialized]
        public BuildMaterial buildMaterial;
        public List<CarvableBlock> childBlocks = new List<CarvableBlock>();

        Collider col;
        MeshRenderer rend;

        private void Awake()
        {
            col = GetComponent<Collider>();
            rend = GetComponent<MeshRenderer>();
        }

        public void BuildSubMesh(Vector3 p, Vector3 s,string name)
        {

            var smartBlock = Instantiate(SmartBlockPF, transform.parent);
            smartBlock.subDivider.SmartBlockPF = SmartBlockPF;
            smartBlock.materializer.buildMaterial = buildMaterial;
            smartBlock.subDivider.buildMaterial = buildMaterial;
            smartBlock.materializer.SetDefaultColor();
            smartBlock.carveMaster.enabled = false;//.authority = Authority.Neutral;
            var tf = smartBlock.transform;
            tf.localScale = s;
            tf.position = p;
            childBlocks.Add(smartBlock);
            smartBlock.gameObject.name = name;
            smartBlock.subDivider.col.enabled = false;

            rend.enabled = false;

        }
        public void Restore()
        {

            childBlocks.Iter((x) => x.subDivider.Restore());
            childBlocks.Iter((x) => Destroy(x.gameObject));
            childBlocks = new List<CarvableBlock>();
            rend.enabled = true;
            col.enabled = true;
       
        }
        public void Disable()
        {
            childBlocks.Iter((x) => x.subDivider.col.enabled = true);
            rend.enabled = false;
            col.enabled = false;
        }

        

    }
}
