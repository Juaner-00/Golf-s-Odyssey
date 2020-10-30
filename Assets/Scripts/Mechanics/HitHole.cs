using System.Collections;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Bola en Hoyo");
            Instantiate(obStar, transform.position + offset, Quaternion.identity);
            Invoke("ShowVictoryPanel", time);
            AudioManager.instance.Play("Win");
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
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);

              //  AudioManager.instance.Play("Win");
            }
            else if (count >= limite2Star_inf && count <= limite2Star_sup)
            {
                star1.SetActive(true);
                star2.SetActive(true);

                //  AudioManager.instance.Play("Win");
            }
            else if (count >= limite1Star_inf && count <= limite1Star_sup)
            {
                star1.SetActive(true);
               // AudioManager.instance("BadWin");

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
