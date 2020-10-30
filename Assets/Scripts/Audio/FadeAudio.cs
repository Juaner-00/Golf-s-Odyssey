using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeAudio : MonoBehaviour
{
    public AudioSource source;
   

   /* private void Awake()
    {
        source = GetComponent<AudioSource>();
    }*/

    public void doFade(string finalValue, string duration)
    {
        float value=float.Parse(finalValue);
        float time = float.Parse(duration);

        source.DOFade(value,time);
    }

   
}
