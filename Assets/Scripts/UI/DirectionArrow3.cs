using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DirectionArrow3 : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] Gradient gradiente;
    [SerializeField] Image gradientImage;
    [SerializeField] Image dotImage;
    [SerializeField] TextMeshProUGUI forceText;
    [SerializeField] Color disableColor;

    [SerializeField] Slider sliderArrow;
    PlayerController3 playerController;

    Vector2 size;
    Vector2 sizeMango;

    public static DirectionArrow3 Instance { get; private set; }
    public float Value { get => sliderArrow.value; }

    public static event SliderEvent OnRelease;
    public delegate void SliderEvent(float value);

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;

        playerController = FindObjectOfType<PlayerController3>();
    }

    private void Update()
    {
        sliderArrow.maxValue = playerController.maxForce;

        if (PlayerController3.IsStoped)
        {
            sliderArrow.interactable = true;
            SetColor(gradiente.Evaluate(sliderArrow.normalizedValue));
        }
        else
        {
            sliderArrow.interactable = false;
            sliderArrow.value = 0;
            SetColor(disableColor);
        }

        forceText.text = (sliderArrow.normalizedValue * 100).ToString("n0");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnRelease?.Invoke(sliderArrow.value);
        sliderArrow.value = 0;

        SetColor(gradiente.Evaluate(sliderArrow.normalizedValue));
    }

    private void SetColor(Color color)
    {
        gradientImage.color = color;
        dotImage.color = color;
        forceText.color = color;
    }

}
