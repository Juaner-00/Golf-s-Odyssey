using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    [SerializeField]
    float multiplicadorFuerza = 50f;

    public float maxForce = 15f;

    [HideInInspector]
    public float forceMag;
    public static bool IsStoped { get; private set; }

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
        DirectionArrow3.OnRelease += Shoot;
    }

    void OnDisable()
    {
        DirectionArrow3.OnRelease -= Shoot;
    }

    void Update()
    {
        //Poner true si está quieto, sino falso
        IsStoped = (rb.velocity.sqrMagnitude < 0.1f) ? true : false;
    }

    private void Shoot(float force)
    {
        // Si está quieto y se le aplica fuerza
        if (IsStoped)
        {
            // Vector dirección
            rb.AddForce(InputManager3.Direction.normalized * force, ForceMode.Impulse);

            // Aumentar el contador de strikes y llamar el evento
            counterStrikes += 1;
            OnStrike?.Invoke(counterStrikes);
        }
    }
}

