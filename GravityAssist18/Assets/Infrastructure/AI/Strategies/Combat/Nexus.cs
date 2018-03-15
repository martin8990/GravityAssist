using UnityEngine;
namespace Infrastructure
{
    public class Nexus : MonoBehaviour
    {
        public int HP = 100;
        public void Hit(int dmg)
        {
            Debug.Log("Game Over");
        }
    }
}


