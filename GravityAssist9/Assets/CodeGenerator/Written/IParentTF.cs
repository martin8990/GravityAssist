using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPrefab{
    Transform Parent { get; set; }
    GameObject Prefab { get; set; }
}
