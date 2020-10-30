using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class LevelsSystem : MonoBehaviour
{
    [SerializeField] GameObject[] canvas;

    [SerializeField] RectTransform logo, play, exit, back;
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

        switch (LevelSelector.lastIsland)
        {
            case Island.Troya:
                ClickTroya(0);
                break;
            case Island.Bruja:
                ClickBruja(0);
                break;
            case Island.Ciclipe:
                ClickCiclope(0);
                break;
            case Island.Sirena:
                ClickSirena(0);
                break;
            case Island.Itaca:
                ClickItaca(0);
                break;
            default:
                camaraBarco.SetActive(true);
                Inicio();
                break;
        }
    }


    // private void LateUpdate()
    // {
    //     foreach (GameObject c in canvas)
    //         c.transform.LookAt(c.transform.position + cam.transform.forward);
    // }

    public void Inicio()
    {
        barco.transform.position = inicial.position;
        barco.transform.DOMove(medio.position, 2.5f);
        logo.DOAnchorPosY(600, 2f).SetDelay(1f).SetEase(izi);
        play.DOAnchorPosY(-500, 3f).SetDelay(1f).SetEase(izi);
        exit.DOAnchorPosY(-650, 3f).SetDelay(1f).SetEase(izi);
        
    }

    public void ClickPlay()
    {
        LevelSelector.lastIsland = Island.None;

        logo.DOAnchorPosY(1500, 2f);
        play.DOAnchorPosY(-1200, 1.5f);
        exit.DOAnchorPosY(-1200, 1.5f);
        back.DOAnchorPosX(-327, 1f).SetDelay(2f);
        camaraIsla.SetActive(true);
        camaraBarco.SetActive(false);
        barco.transform.DOMove(islas.position, 3.5f);
    }

    public void ClickExit()
    {
        _SceneManager.Instance.Quit();
    }

    public void ClickBack()
    {
        LevelSelector.lastIsland = Island.None;
        _SceneManager.Instance.LoadMainMenu();
    }

    //* Botones troya
    public void ClickTroya(float delay = 2)
    {
        LevelSelector.lastIsland = Island.Troya;

        camTroya.SetActive(true);
        camaraIsla.SetActive(false);

        troyaRect.DOAnchorPosX(0, 0.5f).SetDelay(delay);
        back.DOAnchorPosX(900, 0.5f).SetDelay(delay);
    }

    public void DesactivarTroya()
    {
        camTroya.SetActive(false);
        camaraIsla.SetActive(true);

        troyaRect.DOAnchorPosX(-1000, 0.5f);
        back.DOAnchorPosX(-300, 0.5f);
    }

    //* Botones brujas
    public void ClickBruja(float delay = 2)
    {
        LevelSelector.lastIsland = Island.Bruja;

        camBruja.SetActive(true);
        camaraIsla.SetActive(false);
        brujaRect.DOAnchorPosX(0, 0.5f).SetDelay(delay);
        back.DOAnchorPosX(900, 0.5f).SetDelay(delay);
    }

    public void DesactivarBruja()
    {
        camBruja.SetActive(false);
        camaraIsla.SetActive(true);
        brujaRect.DOAnchorPosX(-1000, 0.5f);
        back.DOAnchorPosX(-300, 0.5f);
    }

    //* Botones Ciclopes
    public void ClickCiclope(float delay = 2)
    {
        LevelSelector.lastIsland = Island.Ciclipe;

        camCiclope.SetActive(true);
        camaraIsla.SetActive(false);
        ciclopeRect.DOAnchorPosX(0, 0.5f).SetDelay(delay);
        back.DOAnchorPosX(900, 0.5f).SetDelay(delay);
    }

    public void DesactivarCiclope()
    {
        camCiclope.SetActive(false);
        camaraIsla.SetActive(true);
        ciclopeRect.DOAnchorPosX(-1000, 0.5f);
        back.DOAnchorPosX(-300, 0.5f);
    }

    //* Botones Sirena
    public void ClickSirena(float delay = 2)
    {
        LevelSelector.lastIsland = Island.Sirena;

        camSirena.SetActive(true);
        camaraIsla.SetActive(false);
        sirenaRect.DOAnchorPosX(0, 0.5f).SetDelay(delay);
        back.DOAnchorPosX(900, 0.5f).SetDelay(delay);
    }

    public void DesactivarSirena()
    {
        camSirena.SetActive(false);
        camaraIsla.SetActive(true);
        sirenaRect.DOAnchorPosX(-1000, 0.5f);
        back.DOAnchorPosX(-300, 0.5f);
    }

    //* Botones Itica
    public void ClickItaca(float delay = 2)
    {
        LevelSelector.lastIsland = Island.Itaca;

        camItaca.SetActive(true);
        camaraIsla.SetActive(false);
        itacaRect.DOAnchorPosX(0, 0.5f).SetDelay(delay);
        back.DOAnchorPosX(900, 0.5f).SetDelay(delay);
    }

    public void DesactivarItaca()
    {
        camItaca.SetActive(false);
        camaraIsla.SetActive(true);
        itacaRect.DOAnchorPosX(-1000, 0.5f);
        back.DOAnchorPosX(-300, 0.5f);
    }

}
