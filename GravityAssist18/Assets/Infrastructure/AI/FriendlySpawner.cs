
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class FriendlySpawner : MonoBehaviour
    {
        public FriendlyAIUnit aiPrefab;
        public Camera cam;
        FriendlyAIUnit curUnit;
        public LayerMask FriendlyMask = 17;
        
        public void OnEnable()
        {
            curUnit = Instantiate(aiPrefab);

        }
        public void Commit()
        {
            AIManager.AddAI(curUnit);
            AIManager.friendlies.Add(curUnit);
            enabled = false;
        }
        public void Update()
        {
            var pos = Snap.GetSnappedPos(cam, Vector3.one, ~FriendlyMask);
            curUnit.transform.position = pos;
            if (Input.GetMouseButtonDown(0))
            {
                Commit();
            }

        }

    }
}


