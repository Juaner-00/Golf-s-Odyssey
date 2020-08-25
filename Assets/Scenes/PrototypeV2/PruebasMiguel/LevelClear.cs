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
            if (count < 3)
            {
                scoreTotal = 300;
            }

            else

            if (count < 6)
            {
                scoreTotal = 200;
            }

            else

            if (count >= 6)
            {
                scoreTotal = 100;
            }
        }

        return scoreTotal;
        
        

           
    }
}
