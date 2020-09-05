using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField] Gradient gradiente;

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
        if (PlayerController.isStoped)
        {
            sliderArrow.value = playerController.forceMag;
            arrowImage.color = gradiente.Evaluate(sliderArrow.normalizedValue);
        }
        else
            sliderArrow.value = 0;
    }

}
