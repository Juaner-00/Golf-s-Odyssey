using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionArrow2 : MonoBehaviour
{
    [SerializeField] Gradient gradiente;

    Image arrowImage;
    Slider sliderArrow;
    PlayerController2 playerController;

    private void Awake()
    {
        sliderArrow = GetComponentInChildren<Slider>();
        playerController = FindObjectOfType<PlayerController2>();
        arrowImage = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        sliderArrow.maxValue = playerController.maxForce;
    }

    private void Update()
    {
        if (PlayerController2.isStoped)
        {
            sliderArrow.value = playerController.forceMag;
            arrowImage.color = gradiente.Evaluate(sliderArrow.normalizedValue);
        }
        else
            sliderArrow.value = 0;
    }

}