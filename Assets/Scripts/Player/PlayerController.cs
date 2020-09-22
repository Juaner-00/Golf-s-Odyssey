﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float multiplicadorFuerza = 0.2f;

    public float maxForce = 100f;

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
        InputManager.OnShoot += Shoot;
    }

    void OnDisable()
    {
        InputManager.OnShoot -= Shoot;
    }

    void Update()
    {
        //Poner true si está quieto, sino falso
        isStoped = (rb.velocity.sqrMagnitude < 0.1f) ? true : false;

        // Clamp a la fuerza
        forceMag = Mathf.Abs(InputManager.VectorSwipe.magnitude * multiplicadorFuerza);
        forceMag = Mathf.Clamp(forceMag, 0, maxForce);
    }

    private void Shoot()
    {
        // Si está quieto y se le aplica fuerza
        if (isStoped)
        {
            // Vector dirección
            // Vector3 direction = Vector3.ProjectOnPlane(cameraTrans.forward, Vector3.up).normalized;
            Vector3 direction = InputManager.VectorSwipe.normalized;
            rb.AddForce(direction * forceMag, ForceMode.Impulse);

            // Aumentar el contador de strikes y llamar el evento
            counterStrikes += 1;
            OnStrike?.Invoke(counterStrikes);
        }
    }
}

