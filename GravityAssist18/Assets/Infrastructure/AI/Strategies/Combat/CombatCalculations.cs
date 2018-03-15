using System.Collections.Generic;
using Utility;

namespace Infrastructure
{
    public static class CombatCalculations
    {
        public static float GetDefenceRating(List<Armor> armor, float Agility,float AgilityMod,float Strength, float StrengthMod)
        {
            float armorValue = 0;
            armor.Iter((x) => armorValue += x.Rating);
            return armorValue + AgilityMod * Agility + Strength * StrengthMod;
        }
     


    }
}


