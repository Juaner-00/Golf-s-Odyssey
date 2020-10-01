using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField] Gradient gradiente;
    [SerializeField] RectTransform rot;

    RectTransform safeZone;
    Image arrowImage;
    Slider sliderArrow;
    PlayerController playerController;

    Vector2 size;

    private void Awake()
    {
        sliderArrow = GetComponent<Slider>();
        playerController = FindObjectOfType<PlayerController>();
        arrowImage = GetComponentInChildren<Image>();
        safeZone = GameObject.FindGameObjectWithTag("SafeZone").GetComponent<RectTransform>();
    }

    private void Start()
    {
        sliderArrow.maxValue = playerController.maxForce;
        size = new Vector2(InputManager.Instance.porcentajeALaBola / 100 * Screen.height, InputManager.Instance.porcentajeALaBola / 100 * Screen.height);
    }

    private void Update()
    {
        if (PlayerController.isStoped)
        {
            sliderArrow.value = playerController.forceMag;
            arrowImage.color = gradiente.Evaluate(sliderArrow.normalizedValue);

            safeZone.position = InputManager.PlayerPos;

            Vector2 sizeDelta = (size - new Vector2(InputManager.Dist * Screen.height, InputManager.Dist * Screen.height)) * 6;
            safeZone.sizeDelta = sizeDelta.x < 0 ? Vector2.zero : sizeDelta;
            // safeZone.sizeDelta = new Vector2(InputManager.SwipeDist * Screen.height, InputManager.SwipeDist * Screen.height) * 2;
        }
        else
        {
            sliderArrow.value = 0;
            safeZone.sizeDelta = Vector2.zero;
        }

        //Rotación
        Vector3 deg = rot.localEulerAngles;
        rot.localEulerAngles = new Vector3(deg.x, deg.y, InputManager.Angle);
    }

}
