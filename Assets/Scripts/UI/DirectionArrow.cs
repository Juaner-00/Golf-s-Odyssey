﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField] Gradient gradiente;
    [SerializeField] RectTransform rot;
    [SerializeField] Image arrowImage;

    RectTransform safeZone;

    Slider sliderArrow;
    PlayerController playerController;

    Vector2 size;
    Vector2 sizeMango;


    private void Awake()
    {
        sliderArrow = GetComponentInChildren<Slider>();
        playerController = FindObjectOfType<PlayerController>();

        safeZone = GameObject.FindGameObjectWithTag("SafeZone").GetComponent<RectTransform>();
    }

    private void Start()
    {
        sliderArrow.maxValue = playerController.maxForce;
        size = new Vector2(InputManager.Instance.porcentajeALaBola / 100 * Screen.height, InputManager.Instance.porcentajeALaBola / 100 * Screen.height);
    }

    private void Update()
    {
        sliderArrow.maxValue = playerController.maxForce;
        
        if (PlayerController.isStoped)
        {
            if (InputManager.InRange)
            {
                sliderArrow.gameObject.SetActive(true);
                sliderArrow.value = playerController.forceMag;
                arrowImage.color = gradiente.Evaluate(sliderArrow.normalizedValue);
            }
            else
            {
                sliderArrow.gameObject.SetActive(false);
            }

            safeZone.position = InputManager.PlayerPos;

            Vector2 sizeDelta = (size - new Vector2(InputManager.Dist * Screen.height, InputManager.Dist * Screen.height)) *8;
            safeZone.sizeDelta = sizeDelta.x < 0 ? Vector2.zero : sizeDelta;
        }
        else
        {
            sliderArrow.value = 0;
            safeZone.sizeDelta = Vector2.zero;
        }

        //Rotación
        Vector3 deg = rot.localEulerAngles;
        rot.localEulerAngles = new Vector3(deg.x, deg.y, InputManager.Angle - 180);
    }

}
