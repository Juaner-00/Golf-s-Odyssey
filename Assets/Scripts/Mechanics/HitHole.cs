﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HitHole : MonoBehaviour
{
    [SerializeField] GameObject obStar;

    [SerializeField] Vector3 offset = new Vector3(0, 0, 0);

    [SerializeField] float time;

    [SerializeField] TextMeshProUGUI strikeText;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    [SerializeField] int limite3Star_sup;
    [SerializeField] int limite2Star_inf;
    [SerializeField] int limite2Star_sup;
    [SerializeField] int limite1Star_inf;
    [SerializeField] int limite1Star_sup;
    [SerializeField]
    LevelsObject lvlObjects;
    [SerializeField]
    int posLvl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int count = int.Parse(strikeText.text);
            AudioManager.instance.Play("Bola en Hoyo");
            Instantiate(obStar, transform.position + offset, Quaternion.identity);

            if (count <= limite3Star_sup)
                AudioManager.instance.Play("Win");

            else if (count >= limite2Star_inf && count <= limite2Star_sup)
                AudioManager.instance.Play("Win");

            else if (count >= limite1Star_inf && count <= limite1Star_sup)
                AudioManager.instance.Play("Bad Win");

            else if (count > limite1Star_sup)
                AudioManager.instance.Play("Bad Win");


            Invoke("ShowVictoryPanel", time);
            
        }
    }

   

    private void SceneChanger()
    {
        _SceneManager.Instance.LoadNextLevel();
    }

    private void CalculateScore(TextMeshProUGUI strikeCount)
    {
        int count = int.Parse(strikeCount.text);

        if (count != 0)
        {
            if (count <= limite3Star_sup)
            {
                lvlObjects.AsignarEstrellas(posLvl,3);
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
              
            }
            else if (count >= limite2Star_inf && count <= limite2Star_sup)
            {
                lvlObjects.AsignarEstrellas(posLvl, 2);
                star1.SetActive(true);
                star2.SetActive(true);

            }
            else if (count >= limite1Star_inf && count <= limite1Star_sup)
            {
                lvlObjects.AsignarEstrellas(posLvl, 1);
                star1.SetActive(true);

               
            }

            
        }
    }

    private void ShowVictoryPanel()
    {
        CalculateScore(strikeText);

        // Instantiate(obStar, transform.position + offset, Quaternion.identity);
        
        LevelClearManager.Instance.ShowLevelDialog("Level Cleared", strikeText.text.ToString());
    }
}
