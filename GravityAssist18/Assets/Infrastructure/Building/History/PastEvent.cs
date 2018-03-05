using UnityEngine;
using System.Collections;
namespace Infrastructure
{
    public abstract class PastEvent
    {
        public abstract IEnumerator Undo();
        public abstract IEnumerator Redo();
        public abstract void CleanUp();
    }


}
