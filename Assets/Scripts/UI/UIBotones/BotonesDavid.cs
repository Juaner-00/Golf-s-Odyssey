using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class BotonesDavid : MonoBehaviour
{

    [SerializeField]
    GameObject[] canvas;
    
    Camera cam;
    [SerializeField]
    RectTransform logo,play,exit;
    [SerializeField]
    GameObject barco,menuTroya,menuBruja,menuCiclope,menuSirena,menuItaca;
    [SerializeField]
    GameObject camaraIsla, camaraBarco,camTroya,camBruja,camCiclope,camSirena,camItaca;
    [SerializeField]
    Transform inicial, medio, islas;
    [SerializeField]
    Ease izi;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        barco.transform.position = inicial.position;
        barco.transform.DOMove(medio.position, 3f);
        logo.DOAnchorPosY(600, 2f).SetDelay(1f).SetEase(izi);
        play.DOAnchorPosY(-500, 3f).SetDelay(1f).SetEase(izi);
        exit.DOAnchorPosY(-650, 3f).SetDelay(1f).SetEase(izi);

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void LateUpdate()
    {
        foreach(GameObject c in canvas)
        {
            c.transform.LookAt(c.transform.position + cam.transform.forward);
        }
        

    }
    public void ClickPlay()
    {
        logo.DOAnchorPosY(1500, 2f);
        play.DOAnchorPosY(-1200, 2f);
        exit.DOAnchorPosY(-1200, 2f);
        camaraIsla.SetActive(true);
        camaraBarco.SetActive(false);
        barco.transform.DOMove(islas.position,3f);
       
    }
    public void ClickExit()
    {
        _SceneManager.Instance.Quit();
    }

    //botones troya
    public void ClickTroya()
    {
        camTroya.SetActive(true);
        camaraIsla.SetActive(false);
        
        
        menuTroya.GetComponent<RectTransform>().DOAnchorPosX(0,0.5f).SetDelay(2f);
    }
    public void DesactivarTroya()
    {
        camTroya.SetActive(false);
        camaraIsla.SetActive(true);
        
        menuTroya.GetComponent<RectTransform>().DOAnchorPosX(-1000, 0.5f);
    }

    //botones brujas
    public void ClickBruja()
    {
        camBruja.SetActive(true);
        camaraIsla.SetActive(false);
        menuBruja.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f).SetDelay(2f);
    }
    public void DesactivarBruja()
    {
        camBruja.SetActive(false);
        camaraIsla.SetActive(true);
        menuBruja.GetComponent<RectTransform>().DOAnchorPosX(-1000, 0.5f);
    }

    //botones Ciclopes
    public void ClickCiclope()
    {
        camCiclope.SetActive(true);
        camaraIsla.SetActive(false);
        menuCiclope.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f).SetDelay(2f);
    }
    public void DesactivarCiclope()
    {
        camCiclope.SetActive(false);
        camaraIsla.SetActive(true);
        menuCiclope.GetComponent<RectTransform>().DOAnchorPosX(-1000, 0.5f);
    }

    //botones Sirena
    public void ClickSirena()
    {
        camSirena.SetActive(true);
        camaraIsla.SetActive(false);
        menuSirena.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f).SetDelay(2f);
    }
    public void DesactivarSirena()
    {
        camSirena.SetActive(false);
        camaraIsla.SetActive(true);
        menuSirena.GetComponent<RectTransform>().DOAnchorPosX(-1000, 0.5f);
    }

    //botones Itica
    public void ClickItaca()
    {
        camItaca.SetActive(true);
        camaraIsla.SetActive(false);
        menuItaca.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f).SetDelay(2f);
    }
    public void DesactivarItaca()
    {
        camItaca.SetActive(false);
        camaraIsla.SetActive(true);
        menuItaca.GetComponent<RectTransform>().DOAnchorPosX(-1000, 0.5f);
    }

}
