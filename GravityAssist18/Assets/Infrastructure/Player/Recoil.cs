using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class Recoil : MonoBehaviour
    {
        public Transform grip;
        public int RecoilFrames;
        public float recoilPerFrame;
        IEnumerator StartRecoil()
        {
            for (int i = 0; i < recoilPerFrame; i++)
            {
                var prevPos = grip.transform.localPosition;
                grip.transform.localPosition = new Vector3(prevPos.x, prevPos.y, prevPos.z - recoilPerFrame);
                yield return new WaitForSecondsRealtime(0.016f);
            }
            for (int i = 0; i < recoilPerFrame; i++)
            {
                var prevPos = grip.transform.localPosition;
                grip.transform.localPosition = new Vector3(prevPos.x, prevPos.y, prevPos.z + recoilPerFrame);
                yield return new WaitForSecondsRealtime(0.016f);
            }
        }
    }




}


