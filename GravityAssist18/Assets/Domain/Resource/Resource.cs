using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Domain
{
    public abstract class Resource : MonoBehaviour
    {
        public float Mass;
    }

    public class Metal : Resource
    {
        public float Strength;
        public float Conductivity;
        public float Energy;

    }

    public class Chemical : Resource
    {

    }

    public class Composition
    {

    }

    
}
