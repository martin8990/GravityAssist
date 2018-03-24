using UnityEngine;
namespace Infrastructure
{
    public class ColorManager : MonoBehaviour
    {
        public Color defaultColor;
        public Color toMineColor;
        public Color mouseOverColor;


        public static Color DefaultColor;
        public static Color ToMineColor;
        public static Color MouseOverColor;


        private void Awake()
        {
            DefaultColor = defaultColor;
            ToMineColor = toMineColor;
            MouseOverColor = mouseOverColor;
        }


    }

}


