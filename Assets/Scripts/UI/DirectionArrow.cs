using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField] Gradient gradiente;
    [SerializeField] RectTransform rot;

    Image arrowImage;
    Slider sliderArrow;
    PlayerController playerController;

    Transform camTrans;

    private void Awake()
    {
        sliderArrow = GetComponent<Slider>();
        playerController = FindObjectOfType<PlayerController>();
        arrowImage = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        camTrans = Camera.main.transform;
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

        //Rotación
        Vector3 forward = Vector3.ProjectOnPlane(camTrans.forward, Vector3.up).normalized;
        // float ang = Mathf.Atan2()
        float ang = Vector3.Angle(forward, InputManager.VectorSwipe);

        Vector3 deg = rot.localEulerAngles;
        rot.localEulerAngles = new Vector3(deg.x, deg.y, ang);
    }

}
