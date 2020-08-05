﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionArrow : MonoBehaviour
{
    public Gradient gradiente;


    Image arrowImage;
    Slider sliderArrow;
    PlayerController playerController;

    private void Awake()
    {
        sliderArrow = GetComponent<Slider>();
        playerController = FindObjectOfType<PlayerController>();
        arrowImage = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        sliderArrow.maxValue = playerController.maxForce;
    }

    private void Update()
    {
        sliderArrow.value = playerController.forceMag;
        arrowImage.color = gradiente.Evaluate(sliderArrow.normalizedValue);
    }

}
