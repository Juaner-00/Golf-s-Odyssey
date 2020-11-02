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

<<<<<<< HEAD
            
=======
            else
                StartCoroutine(ShowStars(0));


>>>>>>> master
        }
    }

    private void ShowVictoryPanel()
    {
        CalculateScore(strikeText);

        // Instantiate(obStar, transform.position + offset, Quaternion.identity);
        
        LevelClearManager.Instance.ShowLevelDialog("Level Cleared", strikeText.text.ToString());
    }
<<<<<<< HEAD
=======

    IEnumerator ShowStars(int stars)
    {
        star1Rec.DOScale(Vector3.zero, 0);
        star2Rec.DOScale(Vector3.zero, 0);
        star3Rec.DOScale(Vector3.zero, 0);
       
        if(stars>=2)
            AudioManager.instance.Play("Win");
        else
        
            AudioManager.instance.Play("Bad Win");
        yield return new WaitForSeconds(timeStars * 1.5f);

        switch (stars)
        {
            case 3:

                // audio star
          //      AudioManager.instance.Play("Star1");
                star1Rec.DOScale(Vector3.one, timeStars).SetEase(ease);                
                yield return new WaitForSeconds(timeStars * 1.5f);

                // audio star
             //   AudioManager.instance.Play("Star2");
                star2Rec.DOScale(Vector3.one, timeStars).SetEase(ease);                
                yield return new WaitForSeconds(timeStars * 1.5f);

                // audio star
         //       AudioManager.instance.Play("Star3");
                star3Rec.DOScale(Vector3.one, timeStars).SetEase(ease);

                // audioWin
                yield return new WaitForSeconds(timeStars * 0f);
                
                break;
            case 2:
                // audio star
           //     AudioManager.instance.Play("Star1");
                star1Rec.DOScale(Vector3.one, timeStars).SetEase(ease);
                yield return new WaitForSeconds(timeStars * 1.5f);

                // audio star
          //      AudioManager.instance.Play("Star2");
                star2Rec.DOScale(Vector3.one, timeStars).SetEase(ease);

                // audioWin
                yield return new WaitForSeconds(timeStars * 1.5f);
                //AudioManager.instance.Play("Win");
                break;
            case 1:
                // audio star
            //    AudioManager.instance.Play("Star1");
                star1Rec.DOScale(Vector3.one, timeStars).SetEase(ease);

                // adioWin
             // AudioManager.instance.Play("Bad Win");
                break;
        }

    }
>>>>>>> master
}
