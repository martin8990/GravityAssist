using UnityEngine;
namespace Infrastructure
{
    public class ColorManager : MonoBehaviour
    {
        public Color defaultColor;
        public Color toMineColor;
        public Color mouseOverColor;
        public string materialColorId;


        public static Color DefaultColor;
        public static Color ToMineColor;
        public static Color MouseOverColor;
        public static string MaterialColorId;

        private void Awake()
        {
            DefaultColor = defaultColor;
            ToMineColor = toMineColor;
            MouseOverColor = mouseOverColor;

        }


    }

}


