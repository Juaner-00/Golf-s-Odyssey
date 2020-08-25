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

    TextMeshProUGUI scoreText;

      [SerializeField]

      _SceneManager nextScene;

    [SerializeField]
    LevelClearManager levelClearedManager;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;


    private void OnTriggerEnter(Collider other)
    {
        //scoreText.text = strikeText.text.ToString();

        scoreText.text = CalculateScore(strikeText).ToString();

        if (other.CompareTag("Player"))
        {
            Instantiate(obStar, transform.position + offset, Quaternion.identity);
            //Invoke("SceneChanger", time);

            levelClearedManager.ShowLevelDialog("Level Cleared", scoreText.text, strikeText.text.ToString());

        }
    }

    


    private void SceneChanger()
    {
        nextScene.LoadLevel();

    }

    private int CalculateScore(TextMeshProUGUI strikeCount)
    {
        int scoreTotal = 0;

        int count = int.Parse(strikeCount.text);

        if( count != 0 )
        {
            if (count < 4)
            {
                scoreTotal = 300;

                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }

            else

            if (count < 7)
            {
                scoreTotal = 200;

                star1.SetActive(true);
                star2.SetActive(true);
            }

            else

            if (count >= 7)
            {
                scoreTotal = 100;
                star1.SetActive(true);
            }
        }

        return scoreTotal;
        
        

           
    }
}
