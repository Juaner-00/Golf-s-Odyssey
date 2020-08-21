using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector3 vectorSwipe;
    public static Vector3 deltaMousePos;
    public static Vector3 deltaTouchPos;

    Vector3 posIni;
    Vector3 posFin;

    Vector3 panStart;

    public event EventHandler OnShoot;


    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Mouse

        // Setear el vector posIni a la posición del mouse
        if (Input.GetMouseButtonDown(0))
        {
            posIni = Input.mousePosition;
            panStart = cam.ScreenToWorldPoint(posIni);
        }
        // Setear el vector posFin al mantener el botón del mouse
        else if (Input.GetMouseButton(0))
        {
            posFin = Input.mousePosition;
            deltaMousePos = panStart - cam.ScreenToWorldPoint(posFin);
            vectorSwipe = CalcularDistancia();
        }
        // Activar el evento si se soltó el botón del mouse
        else if (Input.GetMouseButtonUp(0))
        {
            OnShoot?.Invoke(this, EventArgs.Empty);
            vectorSwipe = Vector3.zero;
            deltaMousePos = Vector3.zero;
        }

        // Touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Setear el vector posIni a la posición del touch
            if (touch.phase == TouchPhase.Began)
            {
                posIni = touch.position;
                panStart = cam.ScreenToWorldPoint(posIni);
            }
            // Setear el vector posFin a la posición del touch
            else if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) &&
            Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x) * 1.5f)
            {
                posFin = touch.position;
                deltaTouchPos = panStart - cam.ScreenToWorldPoint(posFin);
                vectorSwipe = CalcularDistancia();
            }
            // Activar el evento si soltó el touch
            else if (touch.phase == TouchPhase.Ended)
            {
                OnShoot?.Invoke(this, EventArgs.Empty);
                vectorSwipe = Vector3.zero;
                deltaTouchPos = Vector3.zero;
            }
        }
    }

    Vector2 CalcularDistancia()
    {
        return (posIni - posFin) / Screen.height;
    }
}
