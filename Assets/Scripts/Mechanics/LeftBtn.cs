using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftBtn : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed;

    // Start is called before the first frame update
    public void OnUpdateSelected(BaseEventData data)
    {
        InputMapper3.Mult = isPressed ? 1 : 0;
    }

    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}

