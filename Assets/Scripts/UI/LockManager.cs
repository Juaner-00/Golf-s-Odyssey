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

    [SerializeField]
    Transform menuTroya, menuCiclope, menuSirenas, menuItaca;

    GameObject[] esNivel;
    public static bool accederCiclope, accederSirenas, accederItaca, accederBrujas;

    // Start is called before the first frame update
    private void Start()
    {
        esNivel = new GameObject[12];
        
        esNivel[0] = menuTroya.GetChild(6).gameObject;
        esNivel[1] = menuTroya.GetChild(7).gameObject;
        esNivel[2] = menuTroya.GetChild(8).gameObject;

        esNivel[3]= menuCiclope.GetChild(6).gameObject;
        esNivel[4] = menuCiclope.GetChild(7).gameObject;
        esNivel[5] = menuCiclope.GetChild(8).gameObject;

        esNivel[6] = menuSirenas.GetChild(6).gameObject;
        esNivel[7] = menuSirenas.GetChild(7).gameObject;
        esNivel[8] = menuSirenas.GetChild(8).gameObject;

        esNivel[9] = menuItaca.GetChild(6).gameObject;
        esNivel[10] = menuItaca.GetChild(7).gameObject;
        esNivel[11] = menuItaca.GetChild(8).gameObject;



        for (int i= 0; i < 12; i++)
        {
            for(int j = 0; j < lvlObject.lista[i];j++)
            {
                esNivel[i].transform.GetChild(j).gameObject.SetActive(true);
            }
        }
    }
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
            mCiclope.color = colorGeneral;
        }

        if (lvlObject.starCount >= estrellasParaSirena)
        {
            accederSirenas = true;
            candadoSineras.SetActive(false);
            mSirenas.color = colorGeneral;
        }
        if (lvlObject.starCount >= estrellasParaItaca)
        {
            accederItaca = true;
            candadoItaca.SetActive(false);
            mItaca.color = colorGeneral;
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
