using UnityEngine;
using Utility;
using System;
namespace Infrastructure
{

    public class CarvableBlock : MonoBehaviour
    {
        public CarveLogic carveLogic;
        public Materializer materializer;
        public SubDivider subDivider;
        public Triggerer collisionTriggerer;
        public bool valid;
        
        public Action<Vector3Int,Vector3Int> Carve;
        public Action Restore;

        public Action Disable;
        public Action Commit;
        
        private void Awake()
        {

            Carve = carveLogic.GetCarved;
            Restore = subDivider.Restore;
            Disable = subDivider.Disable;

            carveLogic.OnBuildBlock = subDivider.BuildSubMesh;
        }                
     }
}
