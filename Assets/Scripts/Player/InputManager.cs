using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector3 vectorSwipe;

    Vector3 posIni;
    Vector3 posFin;

    public event EventHandler OnShoot;

    PlayerController playerController;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.isStoped)
        {
            // Mouse

            // Setear el vector posIni a la posición del mouse
            if (Input.GetMouseButtonDown(0))
            {
                posIni = Input.mousePosition;
            }
            // Setear el vector posFin al mantener el botón del mouse
            else if (Input.GetMouseButton(0))
            {
                posFin = Input.mousePosition;
                vectorSwipe = CalcularDistancia();
            }
            // Activar el evento si se soltó el botón del mouse
            else if (Input.GetMouseButtonUp(0))
            {
                OnShoot?.Invoke(this, EventArgs.Empty);
                vectorSwipe = Vector3.zero;
            }

            // Touch
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Setear el vector posIni a la posición del touch
                if (touch.phase == TouchPhase.Began)
                {
                    posIni = touch.position;
                }
                // Setear el vector posFin a la posición del touch
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    posFin = touch.position;
                    vectorSwipe = CalcularDistancia();
                }
                // Activar el evento si soltó el touch
                else if (touch.phase == TouchPhase.Ended)
                {
                    OnShoot?.Invoke(this, EventArgs.Empty);
                    vectorSwipe = Vector3.zero;
                }
            }
        }
    }

    Vector3 CalcularDistancia()
    {
        return (posIni - posFin)/Screen.height;
    }
}
