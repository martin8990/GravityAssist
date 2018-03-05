using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class HistoryManager : MonoBehaviour
    {
        List<PastEvent> history = new List<PastEvent>();
        public int cnt = 0;

        public void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
            {
                Undo();
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Y))
            {
                Redo();
            }
        }

        void Undo()
        {
            if (cnt > 0)
            {

                cnt--;
                StartCoroutine(history[cnt].Undo());
                
            }            
        }

        void Redo()
        {
            if (history.Count > cnt)
            {

                StartCoroutine(history[cnt].Redo());
                cnt++;
            }
        }
        public void AddElement(PastEvent element)
        {


            for (int i = cnt; i < history.Count; i++)
            {
                history.RemoveAt(i);
            }
            history.Add( element);
            cnt++;
        }

    }


}
