using UnityEngine;

namespace Infrastructure
{
    public abstract class Hexagon : MonoBehaviour
    {
        public int MiningCost = 1;
        public abstract void OnPickup();

        public void ChangeColor(Color col)
        {
            GetComponent<MeshRenderer>().material.color = col;
        }
    }

}


