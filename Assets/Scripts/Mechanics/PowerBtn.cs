using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PowerBtn : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float speed;

    bool isPressed;
    float pressed;

    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    // Start is called before the first frame update
    public void OnUpdateSelected(BaseEventData data)
    {
        pressed += isPressed ? Time.deltaTime * speed : 0;
        DirectionArrow3.Instance.sliderArrow.value = pressed;
    }

    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
        pressed = 0;
        DirectionArrow3.Instance.Release();
    }

    private void Update()
    {
        button.interactable = PlayerController3.IsStoped ? true : false;
    }
}

