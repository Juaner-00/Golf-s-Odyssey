using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class LevelsSystem : MonoBehaviour
{
    [SerializeField] GameObject[] canvas;

    [SerializeField] RectTransform logo, play, exit;
    [SerializeField] GameObject barco, menuTroya, menuBruja, menuCiclope, menuSirena, menuItaca;
    [SerializeField] GameObject camaraIsla, camaraBarco, camTroya, camBruja, camCiclope, camSirena, camItaca;
    [SerializeField] Transform inicial, medio, islas;
    [SerializeField] Ease izi;

    Camera cam;
    RectTransform troyaRect, brujaRect, ciclopeRect, sirenaRect, itacaRect;


    private void Awake()
    {
        troyaRect = menuTroya.GetComponent<RectTransform>();
        brujaRect = menuBruja.GetComponent<RectTransform>();
        ciclopeRect = menuCiclope.GetComponent<RectTransform>();
        sirenaRect = menuSirena.GetComponent<RectTransform>();
        itacaRect = menuItaca.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        barco.transform.position = inicial.position;
        barco.transform.DOMove(medio.position, 2.5f);
        logo.DOAnchorPosY(600, 2f).SetDelay(1f).SetEase(izi);
        play.DOAnchorPosY(-500, 3f).SetDelay(1f).SetEase(izi);
        exit.DOAnchorPosY(-650, 3f).SetDelay(1f).SetEase(izi);
    }

    private void LateUpdate()
    {
        foreach (GameObject c in canvas)
            c.transform.LookAt(c.transform.position + cam.transform.forward);
    }

    public void ClickPlay()
    {
        logo.DOAnchorPosY(1500, 2f);
        play.DOAnchorPosY(-1200, 1.5f);
        exit.DOAnchorPosY(-1200, 1.5f);
        camaraIsla.SetActive(true);
        camaraBarco.SetActive(false);
        barco.transform.DOMove(islas.position, 3.5f);
    }

    public void ClickExit()
    {
        _SceneManager.Instance.Quit();
    }

    //* Botones troya
    public void ClickTroya()
    {
        camTroya.SetActive(true);
        camaraIsla.SetActive(false);

        troyaRect.DOAnchorPosX(0, 0.5f).SetDelay(2f);
    }

    public void DesactivarTroya()
    {
        camTroya.SetActive(false);
        camaraIsla.SetActive(true);

        troyaRect.DOAnchorPosX(-1000, 0.5f);
    }

    //* Botones brujas
    public void ClickBruja()
    {
        camBruja.SetActive(true);
        camaraIsla.SetActive(false);
        brujaRect.DOAnchorPosX(0, 0.5f).SetDelay(2f);
    }

    public void DesactivarBruja()
    {
        camBruja.SetActive(false);
        camaraIsla.SetActive(true);
        brujaRect.DOAnchorPosX(-1000, 0.5f);
    }

    //* Botones Ciclopes
    public void ClickCiclope()
    {
        camCiclope.SetActive(true);
        camaraIsla.SetActive(false);
        ciclopeRect.DOAnchorPosX(0, 0.5f).SetDelay(2f);
    }

    public void DesactivarCiclope()
    {
        camCiclope.SetActive(false);
        camaraIsla.SetActive(true);
        ciclopeRect.DOAnchorPosX(-1000, 0.5f);
    }

    //* Botones Sirena
    public void ClickSirena()
    {
        camSirena.SetActive(true);
        camaraIsla.SetActive(false);
        sirenaRect.DOAnchorPosX(0, 0.5f).SetDelay(2f);
    }

    public void DesactivarSirena()
    {
        camSirena.SetActive(false);
        camaraIsla.SetActive(true);
        sirenaRect.DOAnchorPosX(-1000, 0.5f);
    }

    //* Botones Itica
    public void ClickItaca()
    {
        camItaca.SetActive(true);
        camaraIsla.SetActive(false);
        itacaRect.DOAnchorPosX(0, 0.5f).SetDelay(2f);
    }

    public void DesactivarItaca()
    {
        camItaca.SetActive(false);
        camaraIsla.SetActive(true);
        itacaRect.DOAnchorPosX(-1000, 0.5f);
    }

}
