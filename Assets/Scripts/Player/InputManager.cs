﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] float porcentajeALosBordes = 30f;
    [SerializeField] float porcentajeALaBola = 4f;

    public static Vector3 VectorSwipe { get; private set; }
    public static Vector3 Direction { get; private set; }
    public static Vector3 DeltaMousePos { get; private set; }

    Vector3 posIni;
    Vector3 posFin;

    Vector3 playerPos;

    public static event InputEvent OnShoot;
    public delegate void InputEvent();

    private new Camera camera;

    [SerializeField]
    private DeviceType device;

    public static bool InRange { get; private set; }
    public static bool CanShoot { get; private set; }

    public static float Angle { get; private set; }
    public static float DistTurn { get; private set; }

    Touch touch;

    Vector3 currentPos, lastPos;

    private void Start()
    {
        camera = Camera.main;

        playerPos = camera.WorldToScreenPoint(transform.position);
        posIni = posFin = playerPos;

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
            playerPos = camera.WorldToScreenPoint(transform.position);

            float dist = Vector3.Distance(playerPos, posFin) / Screen.height;

            CanShoot = (InRange && dist > porcentajeALaBola / 100);

            //* Mouse
            if (device == DeviceType.PC)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    posIni = Input.mousePosition;

                    dist = Vector3.Distance(playerPos, posIni) / Screen.height;

                    if (dist <= porcentajeALaBola / 100)
                        InRange = true;
                }

                posFin = Input.mousePosition;

                if (InRange)
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (CanShoot)
                            CalcularDistancia();
                        else
                            VectorSwipe = Vector3.zero;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        if (CanShoot)
                        {
                            OnShoot?.Invoke();

                            posIni = posFin = playerPos;
                            VectorSwipe = Vector3.zero;
                            InRange = false;
                            CanShoot = false;
                        }
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

                        dist = Vector3.Distance(playerPos, posIni) / Screen.height;

                        if (dist <= porcentajeALaBola / 100)
                            InRange = true;
                    }

                    posFin = touch.position;

                    if (InRange)
                    {
                        if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                        {
                            if (CanShoot)
                                CalcularDistancia();
                            else
                                VectorSwipe = Vector3.zero;
                        }

                        if (touch.phase == TouchPhase.Ended)
                        {
                            if (CanShoot)
                            {
                                OnShoot?.Invoke();

                                posIni = posFin = playerPos;
                                VectorSwipe = Vector3.zero;
                                InRange = false;
                                CanShoot = false;
                            }
                        }
                    }
                }
            }

            // if (CanShoot)
            // {
            // Distancia a los bordes
            if (posFin.x / Screen.width < porcentajeALosBordes / 100)
                DistTurn = -((porcentajeALosBordes / 100) - posFin.x / Screen.width);
            else if ((1 - posFin.x / Screen.width) < porcentajeALosBordes / 100)
                DistTurn = (porcentajeALosBordes / 100) - (1 - posFin.x / Screen.width);
            else
                DistTurn = 0;
            // }

            // DeltaMousePos
            currentPos = Input.mousePosition;
            DeltaMousePos = currentPos - lastPos;
            lastPos = currentPos;


            //Rotación
            Angle = Vector3.SignedAngle(VectorSwipe, Vector3.forward, Vector3.up) + 180;
            float angle = Angle - camera.transform.localEulerAngles.y;
            Direction = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0, Mathf.Cos(angle * Mathf.PI / 180 + (float)Math.PI));
        }
    }

    void CalcularDistancia()
    {
        Vector3 swipe = (posIni - posFin) / Screen.height;
        VectorSwipe = new Vector3(swipe.x, 0, swipe.y);
    }


}

public enum DeviceType
{
    PC,
    Movil
}