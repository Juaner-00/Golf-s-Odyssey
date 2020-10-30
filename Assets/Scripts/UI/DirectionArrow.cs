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
    [SerializeField] AudioClip espadazoFuerte, espadazoMedio, espadazoSuave;

    AudioSource src;

    float forceToLength;
    [SerializeField] Slider charForce;

    float ini;
    float fin;

    private void Awake()
    {
        sliderArrow = GetComponentInChildren<Slider>();
        playerController = FindObjectOfType<PlayerController>();

        safeZone = GameObject.FindGameObjectWithTag("SafeZone").GetComponent<RectTransform>();

    }

    private void OnEnable()
    {
        PlayerController.OnStrike += ShootFx;
    }

    private void OnDisable()
    {
        PlayerController.OnStrike -= ShootFx;
    }

    private void Start()
    {
        src = GetComponent<AudioSource>();

        largoTrayectoria = FindObjectOfType<RayBeam>();
        colorTrayectoria = GetComponentInChildren<LineRenderer>();
        sliderArrow.maxValue = playerController.maxForce;
        size = new Vector2(InputManager.Instance.porcentajeALaBola / 100 * Screen.height, InputManager.Instance.porcentajeALaBola / 100 * Screen.height) * 2;
        // size = safeZone.sizeDelta;

        ini = charForce.minValue;

    }

    private void Update()
    {

        fin = InputManager.SwipeDist * 10;
        forceToLength = InputManager.SwipeDist * 10;

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

            Vector2 sizeDelta = (size - new Vector2(InputManager.Dist * Screen.height, InputManager.Dist * Screen.height) * 2);
            safeZone.sizeDelta = sizeDelta.x < 0 ? Vector2.zero : sizeDelta;
        }
        else
        {
            sliderArrow.value = 0;
            safeZone.sizeDelta = Vector2.zero;
        }

        //Rotación
        Vector3 deg = rot.gameObject.transform.localEulerAngles;
        rot.localEulerAngles = new Vector3(deg.x, deg.y, InputManager.Angle - 180);

        // Efecto al disparar
        // ShootFx(0);
        LineLenght();
    }

    void LineLenght()
    {


        largoTrayectoria.MaxLenght = Mathf.Lerp(ini, 10, forceToLength);

    }

    void ShootFx(int _)
    {
        if (sliderArrow.normalizedValue >= 0f && sliderArrow.normalizedValue <= 0.4f)
        {
            // Debug.Log("Suave");
            Instantiate(hitSuave, playerController.transform.position, Quaternion.identity);
            // src.PlayOneShot(espadazoSuave);
            AudioManager.instance.Play("Espadazo Suave");

        }
        else if (sliderArrow.normalizedValue >= 0.4f && sliderArrow.normalizedValue <= 0.7f)
        {
            // Debug.Log("Medio");
            Instantiate(hitMedio, playerController.transform.position, Quaternion.identity);
            //src.PlayOneShot(espadazoMedio);
            AudioManager.instance.Play("Espadazo Medio");
        }
        else if (sliderArrow.normalizedValue >= 0.7f)
        {
            // Debug.Log("Fuerte");
            Instantiate(debris, playerController.transform.position, Quaternion.identity);
            Instantiate(polvo, playerController.transform.position, Quaternion.identity);
            // src.PlayOneShot(espadazoFuerte);
            AudioManager.instance.Play("Espadazo Fuerte");
        }
        else if (sliderArrow.normalizedValue == 0f)
        {
            // Debug.Log("StandBy");
        }

    }


}