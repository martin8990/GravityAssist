using UnityEngine;
using UnityEngine.UI;

public class MachineInput : MonoBehaviour
{
    RectTransform rect;


    [HideInInspector]

    public bool Dragging = true;
    public RectTransform Rect
    {
        get
        {
            if (rect == null)
            {
                rect = gameObject.GetComponent<RectTransform>();
            }
            return rect;
        }

        set
        {
            rect = value;
        }
    }
    public Transform InputTF;
    public Transform OutputTF;
    public Text nameLabel;

    public void toggleDragging()
    {
        Dragging = !Dragging;
    }

    public void Update()
    {
        if (Dragging)
        {
            GOMouseFollow.FollowMouse(gameObject);
            if (Input.GetMouseButtonUp(0))
            {
                Dragging = false;
            }

            UIPositioner.Resize(0.1f * Input.mouseScrollDelta.y, Rect);
        }
        
    }
   
}

