using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    
    public class UnitSelector : MonoBehaviour
    {
        Vector3 p1;
        Vector3 p2;
        
        public Camera cam;
        bool isSelecting;
        public void OnFirstClick()
        {
            isSelecting = true;
            p1 = Input.mousePosition;
        }
        public List<FriendlyAIUnit> OnUp()
        {
            isSelecting = false;
            var selected = new List<FriendlyAIUnit>();

            for (int i = 0; i < AIManager.friendlies.Count; i++)
            {
                if (IsWithinSelectionBounds(AIManager.friendlies[i].gameObject))
                {
                    selected.Add(AIManager.friendlies[i]);
                }
            }
            return selected;
        }
        void OnGUI()
        {
            if (isSelecting)
            {
                // Create a rect from both mouse positions
                var rect = GetScreenRect(p1, Input.mousePosition);
                DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
                DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
            }
        }
        bool IsWithinSelectionBounds(GameObject gameObject)
        {

            var viewportBounds =
                GetViewportBounds(cam, p1, Input.mousePosition);

            return viewportBounds.Contains(
                cam.WorldToViewportPoint(gameObject.transform.position));
        }


        public static Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
        {
            // Move origin from bottom left to top left
            screenPosition1.y = Screen.height - screenPosition1.y;
            screenPosition2.y = Screen.height - screenPosition2.y;
            // Calculate corners
            var topLeft = Vector3.Min(screenPosition1, screenPosition2);
            var bottomRight = Vector3.Max(screenPosition1, screenPosition2);
            // Create Rect
            return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
        }
        static Texture2D _whiteTexture;
        public static Texture2D WhiteTexture
        {
            get
            {
                if (_whiteTexture == null)
                {
                    _whiteTexture = new Texture2D(1, 1);
                    _whiteTexture.SetPixel(0, 0, Color.white);
                    _whiteTexture.Apply();
                }

                return _whiteTexture;
            }
        }

        public static void DrawScreenRect(Rect rect, Color color)
        {
            GUI.color = color;
            GUI.DrawTexture(rect, WhiteTexture);
            GUI.color = Color.white;
        }

        public static void DrawScreenRectBorder(Rect rect, float thickness, Color color)
        {
            // Top
            DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
            // Left
            DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
            // Right
            DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
            // Bottom
            DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
        }


        public static Bounds GetViewportBounds(Camera camera, Vector3 screenPosition1, Vector3 screenPosition2)
        {
            var v1 = Camera.main.ScreenToViewportPoint(screenPosition1);
            var v2 = Camera.main.ScreenToViewportPoint(screenPosition2);
            var min = Vector3.Min(v1, v2);
            var max = Vector3.Max(v1, v2);
            min.z = camera.nearClipPlane;
            max.z = camera.farClipPlane;

            var bounds = new Bounds();
            bounds.SetMinMax(min, max);
            return bounds;
        }

    }

}


