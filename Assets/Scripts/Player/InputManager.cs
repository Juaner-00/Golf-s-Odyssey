using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] float porcentajeALosBordes = 30f;

    public static Vector3 VectorSwipe { get; private set; }
    public static Vector3 Direction { get; private set; }
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
    public static float DistTurn { get; private set; }

    private void Start()
    {
        camTrans = Camera.main.transform;

        posIni = posFin = new Vector2(Screen.width, Screen.height) / 2;

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

            // Distancia a los bordes
            if (posFin.x / Screen.width < porcentajeALosBordes / 100)
                DistTurn = -((porcentajeALosBordes / 100) - posFin.x / Screen.width);
            else if ((1 - posFin.x / Screen.width) < porcentajeALosBordes / 100)
                DistTurn = (porcentajeALosBordes / 100) - (1 - posFin.x / Screen.width);
            else
                DistTurn = 0;

        }

        //Rotación
        Angle = Vector3.SignedAngle(VectorSwipe, Vector3.forward, Vector3.up) + 180;
        float angle = Angle - camTrans.localEulerAngles.y;
        Direction = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0, Mathf.Cos(angle * Mathf.PI / 180 + (float)Math.PI));
    }

    void CalcularDistancia()
    {
        Vector3 swipe = (posIni - posFin) / Screen.height;
        VectorSwipe = new Vector3(swipe.x, 0, swipe.y);
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