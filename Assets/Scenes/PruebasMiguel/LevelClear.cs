using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class LevelClear : MonoBehaviour
{
    [SerializeField]

    GameObject obStar;

    [SerializeField]

    Vector3 offset = new Vector3(0, 0, 0);

    [SerializeField]

    float time;

    [SerializeField]

    TextMeshProUGUI strikeText;
    
      [SerializeField]

      _SceneManager nextScene;

   

    [SerializeField]
    LevelClearManager levelClearedManager;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    [SerializeField]
    int limite3Star_sup;
    [SerializeField]
    int limite2Star_inf;
    [SerializeField]
    int limite2Star_sup;
    [SerializeField]
    int limite1Star_inf;
    


    private void OnTriggerEnter(Collider other)
    {
        //scoreText.text = strikeText.text.ToString();

        
        if (other.CompareTag("Player"))
        {

            Invoke("ShowVictoryPanel", 1);
        }
    }

    


    private void SceneChanger()
    {
        nextScene.LoadNextLevel();

    }

    private int CalculateScore(TextMeshProUGUI strikeCount)
    {
        int scoreTotal = 0;

        int count = int.Parse(strikeCount.text);

        if( count != 0 )
        {
            if (count <= limite3Star_sup)
            {
                
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }

            else

            if (count >= limite2Star_inf && count <= limite2Star_sup)
            {
                
                star1.SetActive(true);
                star2.SetActive(true);
            }

            else

            if (count >= limite1Star_inf)
            {
               
                star1.SetActive(true);
            }
        }

        return scoreTotal;
        
        

           
    }

    private void ShowVictoryPanel()
    {
        CalculateScore(strikeText);

        Instantiate(obStar, transform.position + offset, Quaternion.identity);
        //Invoke("SceneChanger", time);

        levelClearedManager.ShowLevelDialog("Level Cleared", strikeText.text.ToString());
    }
}
