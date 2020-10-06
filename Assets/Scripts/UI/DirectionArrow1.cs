using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class DirectionArrow1 : MonoBehaviour
{
    [SerializeField] Gradient gradiente;
    [SerializeField] RectTransform rot;
    [SerializeField] Image arrowImage;

    RectTransform safeZone;

    [SerializeField] Slider sliderArrow;
    PlayerController1 playerController;

    Vector2 size;
    Vector2 sizeMango;


    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController1>();

        safeZone = GameObject.FindGameObjectWithTag("SafeZone").GetComponent<RectTransform>();
    }

    private void Start()
    {
        sliderArrow.maxValue = playerController.maxForce;
        size = new Vector2(InputManager1.Instance.porcentajeALaBola / 100 * Screen.height, InputManager1.Instance.porcentajeALaBola / 100 * Screen.height);
    }

    private void Update()
    {
        sliderArrow.maxValue = playerController.maxForce;

        if (PlayerController1.isStoped)
        {
            if (InputManager1.InRange)
            {
                sliderArrow.gameObject.SetActive(true);
                sliderArrow.value = playerController.forceMag;
                arrowImage.color = gradiente.Evaluate(sliderArrow.normalizedValue);
            }
            else
            {
                sliderArrow.gameObject.SetActive(false);
            }

            safeZone.position = InputManager1.PlayerPos;

            Vector2 sizeDelta = (size - new Vector2(InputManager1.Dist * Screen.height, InputManager1.Dist * Screen.height)) * 8;
            safeZone.sizeDelta = sizeDelta.x < 0 ? Vector2.zero : sizeDelta;
        }
        else
        {
            sliderArrow.value = 0;
            safeZone.sizeDelta = Vector2.zero;
        }

        //Rotación
        Vector3 deg = rot.localEulerAngles;
        rot.localEulerAngles = new Vector3(deg.x, deg.y, InputManager1.Angle - 180);
    }

}
