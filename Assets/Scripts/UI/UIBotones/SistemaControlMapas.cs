using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SistemaControlMapas : MonoBehaviour
{
    public Camera camara;
    private int contador = 1;
    public Button derecha;
    public Button izquierda;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 1)
        {
            izquierda.interactable = false;
        }
        else { izquierda.interactable = true; }

        if (contador == 6)
        {
            derecha.interactable = false;
        }
        else { derecha.interactable = true; }
    }
    public void desplazamientoDerecha()
    {
        camara.transform.position += new Vector3(10.8f, 0, 0);

        contador += 1;
    }
    public void desplazamientoIzquierda()
    {
        camara.transform.position += new Vector3(-10.8f, 0, 0);

        contador -= 1;
    }
    public void MapTroya()
    {

    }
}
