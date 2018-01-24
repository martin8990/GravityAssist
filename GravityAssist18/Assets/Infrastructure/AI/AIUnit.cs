using System.Collections.Generic;

using UnityEngine;

namespace Infrastructure
{
    public class AIUnit : MonoBehaviour
    {
        public List<AIModule> AIModules = new List<AIModule>();
        Material mat;
        private void Start()
        {
            mat = GetComponent<MeshRenderer>().material;            
        }

        public void Trigger(float period)
        {
            float biggestUtil = 0;
            AIModule bestModule = null;
            for (int i = 0; i < AIModules.Count; i++)
            {
               float util = AIModules[i].utility.CalculateUtility();
                if (util > biggestUtil)
                {
                    biggestUtil = util;
                    bestModule = AIModules[i];
                }
            }

            if (bestModule!=null)
            {
                mat.color = bestModule.color;
                bestModule.Execute(period);
                
               
            }
                

        }
    }


}


