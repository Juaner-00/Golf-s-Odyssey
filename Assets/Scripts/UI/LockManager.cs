using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockManager : MonoBehaviour
{
    [SerializeField]
    Material mTroya,mCiclope,mSirenas,mItaca,mBrujas;
    [SerializeField]
    Color colorGeneral,colorCambio;


    [SerializeField]
    GameObject candandoCiclope, candadoSineras, candadoItaca, candadoBrujas;

    [SerializeField]
    TextMeshProUGUI textCiclope,textSirenas,textItaca,textBrujas;

    [SerializeField]
    int estrellasParaCiclope, estrellasParaSirena, estrellasParaItaca;

    [SerializeField]
    LevelsObject lvlObject;

    public static bool accederCiclope, accederSirenas, accederItaca, accederBrujas;
    
    // Start is called before the first frame update
    
    void Awake()
    {
        mTroya.color = colorGeneral;
        mCiclope.color = colorCambio;
        mSirenas.color = colorCambio;
        mItaca.color = colorCambio;
        mBrujas.color = colorCambio;

        
        if (lvlObject.starCount >= estrellasParaCiclope)
        {
            accederCiclope = true;
            candandoCiclope.SetActive(false);
        }

        if (lvlObject.starCount >= estrellasParaSirena)
        {
            accederSirenas = true;
            candadoSineras.SetActive(false);
        }
        if (lvlObject.starCount >= estrellasParaItaca)
        {
            accederItaca = true;
            candadoItaca.SetActive(false);
        }



        textCiclope.text = $"{lvlObject.starCount}/{ estrellasParaCiclope}";
        textSirenas.text = $"{lvlObject.starCount}/{ estrellasParaSirena}";
        textItaca.text = $"{lvlObject.starCount}/{ estrellasParaItaca}";

    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
