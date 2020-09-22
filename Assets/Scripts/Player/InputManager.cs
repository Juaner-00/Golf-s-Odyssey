using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Vector3 VectorSwipe { get; private set; }
    public static Vector3 deltaMousePos;
    public static Vector3 deltaTouchPos;

    Vector3 posIni;
    Vector3 posFin;

    Vector3 mPos;

    public static event InputEvent OnShoot;
    public delegate void InputEvent();

    private Transform camTrans;

    [SerializeField]
    private DeviceType device;
    private bool hasMoved;

    private static SwipeType swipeType;
    public static SwipeType SwipeType { get => swipeType; }
    public static float Angle { get; private set; }

    private void Start()
    {
        camTrans = Camera.main.transform;

        bool i = false;
#if UNITY_EDITOR
        i = true;
        device = DeviceType.PC;
#endif
#if UNITY_ANDROID
        if (!i)
            device = DeviceType.Movil;
#endif
    }

    private void Update()
    {
        if (!LevelClearManager.Instance.HasClear)
        {
            //* Mouse
            if (device == DeviceType.PC)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    posIni = Input.mousePosition;
                    posFin = posIni;
                }

                if (Input.GetMouseButton(0))
                {
                    CalcularDistancia();
                    posFin = Input.mousePosition;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    OnShoot?.Invoke();
                    VectorSwipe = Vector3.zero;
                }
            }

            //* Touch
            else
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        posIni = Input.mousePosition;
                        posFin = posIni;
                    }

                    if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {
                        CalcularDistancia();
                        posFin = Input.mousePosition;
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        OnShoot?.Invoke();
                        VectorSwipe = Vector3.zero;
                    }
                }
            }
        }

        //Rotación
        Vector3 forward = Vector3.ProjectOnPlane(camTrans.forward, Vector3.up).normalized;
        Angle = Vector3.SignedAngle(InputManager.VectorSwipe, forward, Vector3.up) + 180;
    }

    void CalcularDistancia()
    {
        Vector3 swipe = (posIni - posFin) / Screen.height;
        VectorSwipe = new Vector3(swipe.x, 0, swipe.y);
        print(VectorSwipe);
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