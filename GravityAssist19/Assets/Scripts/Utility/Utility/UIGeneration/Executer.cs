using System;
using UnityEngine;

namespace Utility
{

    public abstract class Executer : MonoBehaviour
    {
        public abstract void Execute();

    }
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : Attribute
    {

    }

    
}