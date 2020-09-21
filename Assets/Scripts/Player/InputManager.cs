using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Vector3 vectorSwipe;
    public static Vector3 deltaMousePos;
    public static Vector3 deltaTouchPos;

    Vector3 posIni;
    Vector3 posFin;

    Vector3 mPos;

    public static event InputEvent OnShoot;
    public delegate void InputEvent();

    private Camera cam;

    [SerializeField]
    private DeviceType device;
    private bool hasMoved;

    private static SwipeType swipeType;
    public static SwipeType SwipeType { get => swipeType; }

    private void Start()
    {
        cam = Camera.main;
        int i = 0;
#if UNITY_EDITOR
        i = 1;
        device = DeviceType.PC;
#endif
#if UNITY_ANDROID
        if (i != 1)
            device = DeviceType.Movil;
#endif
    }

    void Update()
    {
        if (!LevelClearManager.Instance.HasClear)
        {
            if (device == DeviceType.PC)
            {
                // Mouse

                // Setear el vector posIni a la posición del mouse
                if (Input.GetMouseButtonDown(0))
                {
                    posIni = Input.mousePosition;
                    posFin = posIni;
                }
                // Setear el vector posFin al mantener el botón del mouse
                else if (Input.GetMouseButton(0))
                {
                    if (deltaMousePos.sqrMagnitude > 0)
                    {
                        if (!hasMoved)
                        {
                            // Saber hacia cuál dirección mueve primero
                            if (Mathf.Abs(deltaMousePos.y) >= Mathf.Abs(deltaMousePos.x))
                                swipeType = SwipeType.Vertival;
                            else
                                swipeType = SwipeType.Horizontal;

                            hasMoved = true;
                        }

                        if (swipeType == SwipeType.Vertival)
                            vectorSwipe = CalcularDistancia();
                    }

                    deltaMousePos = posFin - Input.mousePosition;
                    posFin = Input.mousePosition;

                }
                // Activar el evento si se soltó el botón del mouse
                else if (Input.GetMouseButtonUp(0))
                {
                    vectorSwipe = Vector3.zero;
                    deltaMousePos = Vector3.zero;
                    hasMoved = false;

                    if (swipeType == SwipeType.Vertival)
                    {
                        OnShoot?.Invoke();
                    }
                }
            }
            else
            {
                // Touch
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    // Setear el vector posIni a la posición del touch
                    if (touch.phase == TouchPhase.Began)
                    {
                        posIni = touch.position;
                        posFin = posIni;
                    }
                    // Setear el vector posFin a la posición del touch
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        if (!hasMoved)
                        {
                            // Saber hacia cuál dirección mueve primero
                            if (Mathf.Abs(touch.deltaPosition.y) * 1.5f >= Mathf.Abs(touch.deltaPosition.x))
                                swipeType = SwipeType.Vertival;
                            else
                                swipeType = SwipeType.Horizontal;

                            hasMoved = true;
                        }

                        posFin = touch.position;

                        if (swipeType == SwipeType.Vertival)
                            vectorSwipe = CalcularDistancia();

                    }
                    // Activar el evento si soltó el touch
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        vectorSwipe = Vector3.zero;
                        deltaTouchPos = Vector3.zero;
                        hasMoved = false;

                        if (swipeType == SwipeType.Vertival)
                        {
                            OnShoot?.Invoke();
                        }
                    }
                }
            }
        }
    }

    Vector2 CalcularDistancia()
    {
        return (posIni - posFin) / Screen.height;
    }
}

public enum SwipeType
{
    Horizontal,
    Vertival
}

public enum DeviceType
{
    PC,
    Movil
}