using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] float porcentajeALosBordes = 30f;
    [SerializeField] public float porcentajeALaBola = 4f;

    private Vector3 vectorSwipe;

    public static float SwipeDist { get; private set; }

    public static Vector3 Direction { get; private set; }
    public static Vector3 DeltaMousePos { get; private set; }

    Vector3 posIni;
    public static Vector3 posFin { get; private set; }


    public static event InputEvent OnShoot;
    public delegate void InputEvent();

    private new Camera camera;

    [SerializeField]
    private DeviceType device;

    public static Vector3 PlayerPos { get; private set; }
    public static bool InRange { get; private set; }
    public static bool CanShoot { get; private set; }

    public static float Angle { get; private set; }
    public static float DistTurn { get; private set; }
    public static float Dist { get; private set; }

    Touch touch;

    Vector3 currentPos, lastPos;

    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    private void Start()
    {
        camera = Camera.main;

        PlayerPos = camera.WorldToScreenPoint(transform.position);
        posIni = posFin = PlayerPos;

        InRange = false;

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
            PlayerPos = camera.WorldToScreenPoint(transform.position);

            Dist = Vector3.Distance(PlayerPos, posFin) / Screen.height;

            CanShoot = (InRange && Dist > porcentajeALaBola / 100);

            SwipeDist = Dist - porcentajeALaBola / 100;
            if (SwipeDist < 0)
                SwipeDist = 0;

            //* Mouse
            if (device == DeviceType.PC)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    posIni = Input.mousePosition;

                    Dist = Vector3.Distance(PlayerPos, posIni) / Screen.height;

                    if (Dist <= porcentajeALaBola / 100)
                        InRange = true;
                    else
                        InRange = false;
                }

                if (InRange)
                {
                    if (Input.GetMouseButton(0))
                    {
                        posFin = Input.mousePosition;

                        // if (CanShoot)
                            CalcularDistancia();
                        // else
                        //     vectorSwipe = Vector3.zero;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        if (CanShoot)
                        {
                            CanShoot = false;

                            OnShoot?.Invoke();
                        }

                        InRange = false;
                        posIni = posFin = PlayerPos;
                        vectorSwipe = Vector3.zero;
                    }
                }
            }

            //* Touch
            else
            {
                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        posIni = touch.position;

                        Dist = Vector3.Distance(PlayerPos, posIni) / Screen.height;

                        if (Dist <= porcentajeALaBola / 100)
                            InRange = true;
                        else
                            InRange = false;
                    }
                }

                if (InRange)
                {
                    if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {
                        posFin = touch.position;

                        // if (CanShoot)
                            CalcularDistancia();
                        // else
                            // vectorSwipe = Vector3.zero;
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        if (CanShoot)
                        {
                            CanShoot = false;

                            OnShoot?.Invoke();
                        }
                        InRange = false;
                        posIni = posFin = PlayerPos;
                        vectorSwipe = Vector3.zero;
                    }
                }
            }
        }

        // Distancia a los bordes
        if (CanShoot)
        {
            if (posFin.x / Screen.width < porcentajeALosBordes / 100)
                DistTurn = -((porcentajeALosBordes / 100) - posFin.x / Screen.width);
            else if ((1 - posFin.x / Screen.width) < porcentajeALosBordes / 100)
                DistTurn = (porcentajeALosBordes / 100) - (1 - posFin.x / Screen.width);
            else
                DistTurn = 0;
        }
        else
        {
            float mXPos = PlayerPos.x;

            if (Input.GetMouseButton(0))
                mXPos = Input.mousePosition.x;

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    mXPos = touch.position.x;
            }

            if (mXPos / Screen.width < porcentajeALosBordes / 100)
                DistTurn = -((porcentajeALosBordes / 100) - mXPos / Screen.width);
            else if ((1 - mXPos / Screen.width) < porcentajeALosBordes / 100)
                DistTurn = (porcentajeALosBordes / 100) - (1 - mXPos / Screen.width);
            else
                DistTurn = 0;
        }

        // DeltaMousePos
        currentPos = Input.mousePosition;
        DeltaMousePos = currentPos - lastPos;
        lastPos = currentPos;

        //Rotación
        Angle = Vector3.SignedAngle(vectorSwipe, Vector3.forward, Vector3.up) + 180;
        float angle = Angle - camera.transform.localEulerAngles.y;
        Direction = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0, Mathf.Cos(angle * Mathf.PI / 180 + (float)Math.PI));
    }


    void CalcularDistancia()
    {
        Vector3 swipe = (posIni - posFin) / Screen.height;
        vectorSwipe = new Vector3(swipe.x, 0, swipe.y);
    }


}

public enum DeviceType
{
    PC,
    Movil
}