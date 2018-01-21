using System.Collections.Generic;
using UnityEngine;
using Domain;
namespace Infrastructure
{
    [System.Serializable]
    public class Category
    {
       public string name;
       public List<PlaceAble> gameObjects;

    }
}
