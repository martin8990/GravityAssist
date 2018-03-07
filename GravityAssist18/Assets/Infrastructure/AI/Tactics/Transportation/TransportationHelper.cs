using System.Collections.Generic;
using UnityEngine;
using Utility;
namespace Infrastructure
{
    public static class TransportationHelper
    {

        public static Stockpile GetClosestStockPile(List<Stockpile> stockpiles,Vector3 pos)
        {
            Stockpile closestSP = null;
            float mindist = 1000000;
            foreach (var stockpile in stockpiles)
            {
                float dist = pos.SquareDist2(stockpile.transform.position);
                if (dist < mindist && stockpile.nMaterial > 0)
                {
                    closestSP = stockpile;
                    mindist = dist;
                }
            }
            return closestSP;
        }


    }
}




