using UnityEngine;

namespace Utility
{
    public class MonoBehaviourExt : MonoBehaviour
    {
        public bool autoSave = true;

        private void OnApplicationQuit()
        {
            if (autoSave)
            {
                DataPersistor.Save(this);
            }
        }
        

    }
}
