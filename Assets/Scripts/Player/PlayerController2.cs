using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField]
    float multiplicadorFuerza = 50f;

    public float maxForce = 15f;

    [HideInInspector]
    public float forceMag;
    public static bool isStoped;

    public static event OnStrikeEvent OnStrike;
    public delegate void OnStrikeEvent(int count);

    int counterStrikes;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        InputManager3.OnShoot += Shoot;
    }

    void OnDisable()
    {
        InputManager3.OnShoot -= Shoot;
    }

    void Update()
    {
        //Poner true si está quieto, sino falso
        isStoped = (rb.velocity.sqrMagnitude < 0.1f) ? true : false;

        // Clamp a la fuerza
        forceMag = Mathf.Abs(InputManager3.SwipeDist * multiplicadorFuerza);
        forceMag = Mathf.Clamp(forceMag, 0, maxForce);
    }

    private void Shoot()
    {
        // Si está quieto y se le aplica fuerza
        if (isStoped)
        {
            // Vector dirección
            rb.AddForce(InputManager3.Direction.normalized * forceMag, ForceMode.Impulse);

            // Aumentar el contador de strikes y llamar el evento
            counterStrikes += 1;
            OnStrike?.Invoke(counterStrikes);
        }
    }
}

