
using UnityEngine;
namespace Infrastructure
{
    public abstract class Order : MonoBehaviour
    {
        protected void OnComplete()
        {
            Destroy(this);
        }
        public abstract void Execute(int period);
    }

}


