using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.XR.WSA.Input;

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

    LineRenderer colorTrayectoria;
    RayBeam largoTrayectoria;

    [SerializeField] GameObject debris;
    [SerializeField] GameObject polvo;
    [SerializeField] GameObject hitMedio;
    [SerializeField] GameObject hitSuave;
    [SerializeField] GameObject Sword;
    [SerializeField] AudioClip espadazoFuerte, espadazoMedio, espadazoSuave;

    AudioSource src;




    private void Awake()
    {

        sliderArrow = GetComponentInChildren<Slider>();
        playerController = FindObjectOfType<PlayerController>();

        safeZone = GameObject.FindGameObjectWithTag("SafeZone").GetComponent<RectTransform>();

    }

    private void Start()
    {
        src = GetComponent<AudioSource>();

        largoTrayectoria = FindObjectOfType<RayBeam>();
        colorTrayectoria = GetComponentInChildren<LineRenderer>();
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

            Vector2 sizeDelta = (size - new Vector2(InputManager.Dist * Screen.height, InputManager.Dist * Screen.height)) * 8;
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

        // Efecto al disparar
        disparoFx();


    }

    void disparoFx()
    {

        if (sliderArrow.normalizedValue >= 0f && sliderArrow.normalizedValue <= 0.3f)
        {
            largoTrayectoria.MaxLenght = 3;
            if (playerController.released)
            {
                Debug.Log("Suave");
                Instantiate(hitSuave, transform.position, Quaternion.identity);
                src.PlayOneShot(espadazoSuave);
               
                playerController.released = false;
            }
        }
        if (sliderArrow.normalizedValue >= 0.3f && sliderArrow.normalizedValue <= 0.7f)
        {
            largoTrayectoria.MaxLenght = 6;
            if (playerController.released)
            {
                Debug.Log("Medio");

                Instantiate(hitMedio, transform.position, Quaternion.identity);
                src.PlayOneShot(espadazoMedio);

                playerController.released = false;
            }
        }
        if (sliderArrow.normalizedValue >= 0.7f)
        {
            largoTrayectoria.MaxLenght = 11;

            if (playerController.released)
            {
                Debug.Log("Fuerte)");

                Instantiate(debris, transform.position, Quaternion.identity);
                Instantiate(polvo, transform.position, Quaternion.identity);
                src.PlayOneShot(espadazoFuerte);

                playerController.released = false;
            }

        }
        if (sliderArrow.normalizedValue == 0f)
        {
            Debug.Log("StandBy");
        }

    }


}