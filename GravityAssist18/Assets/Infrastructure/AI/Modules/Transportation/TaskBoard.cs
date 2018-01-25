using System.Collections.Generic;

using UnityEngine;

namespace Infrastructure
{
    public class TaskBoard : MonoBehaviour
    {
        public List<Job> jobs = new List<Job>();
        public void RemoveFromBoard(Job job)
        {
            jobs.Remove(job);

        }
    }
    

}


