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
    GameObject barco;
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

    public void ClickTroya()
    {

    }
}
