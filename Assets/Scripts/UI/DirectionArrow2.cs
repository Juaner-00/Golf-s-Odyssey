using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DirectionArrow2 : MonoBehaviour
{
    [SerializeField] Gradient gradiente;
    [SerializeField] Image gradientImage;
    [SerializeField] TextMeshProUGUI forceText;

    Slider sliderArrow;
    PlayerController3 playerController;

    Vector2 size;
    Vector2 sizeMango;


    private void Awake()
    {
        sliderArrow = GetComponentInChildren<Slider>();
        playerController = FindObjectOfType<PlayerController3>();
    }

    private void Update()
    {
        sliderArrow.maxValue = playerController.maxForce;

        if (PlayerController3.IsStoped)
        {
            sliderArrow.enabled = true;
            sliderArrow.value = playerController.forceMag;
            gradientImage.color = gradiente.Evaluate(sliderArrow.normalizedValue);
            forceText.color = gradiente.Evaluate(sliderArrow.normalizedValue);
        }
        else
        {
            sliderArrow.enabled = false;
            sliderArrow.value = sliderArrow.normalizedValue * 100;
        }

        forceText.text = sliderArrow.value.ToString();
    }

}
