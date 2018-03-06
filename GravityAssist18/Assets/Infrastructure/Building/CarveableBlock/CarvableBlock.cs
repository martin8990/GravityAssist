using UnityEngine;
using Utility;
using System;
namespace Infrastructure
{

    public class CarvableBlock : MonoBehaviour
    {
        public CarveLogic carveLogic;
        public Materializer materializer;
        public CarveMaster carveMaster;
        public SubDivider subDivider;
        public bool valid;

        public Action<Vector3Int,Vector3Int> Carve;
        public Action Restore;

        public Action Disable;
        public Action OnUpdate;
        public Action Commit;
        
        private void Awake()
        {

            OnUpdate = carveMaster.OnUpdate;
            Carve = carveLogic.GetCarved;
            Commit = carveMaster.Commit;
            Restore = subDivider.Restore;
            Disable = subDivider.Disable;            
            carveLogic.OnBuildBlock = subDivider.BuildSubMesh;
        }                
     }
}
