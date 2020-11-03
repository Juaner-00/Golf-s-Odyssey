using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;


public class HitHole : MonoBehaviour
{
    [SerializeField] GameObject obStar;

    [SerializeField] Vector3 offset = new Vector3(0, 0, 0);

    [SerializeField] float time;
    [SerializeField] float timeStars;

    [SerializeField] TextMeshProUGUI strikeText;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    [SerializeField] int limite3Star_sup;
    [SerializeField] int limite2Star_inf;
    [SerializeField] int limite2Star_sup;
    [SerializeField] int limite1Star_inf;
    [SerializeField] int limite1Star_sup;
    [SerializeField] ParticleSystem confeti;
    [SerializeField] LevelsObject lvlObjects;

    int posLvl;

    RectTransform star1Rec, star2Rec, star3Rec;

    Ease ease;


    private void Start()
    {
        posLvl = int.Parse(SceneManager.GetActiveScene().name.Split('_')[1]);

        star1Rec = star1.GetComponent<RectTransform>();
        star2Rec = star2.GetComponent<RectTransform>();
        star3Rec = star3.GetComponent<RectTransform>();

        ease = MenuManager.Instance.easeOut;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            confeti.Play();
            int count = int.Parse(strikeText.text);
            AudioManager.instance.Play("Bola en Hoyo");
            Instantiate(obStar, transform.position + offset, Quaternion.identity);

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
                lvlObjects.AsignarEstrellas(posLvl, 3);
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);

                StartCoroutine(ShowStars(3));
            }
            else if (count >= limite2Star_inf && count <= limite2Star_sup)
            {
                lvlObjects.AsignarEstrellas(posLvl, 2);
                star1.SetActive(true);
                star2.SetActive(true);

                StartCoroutine(ShowStars(2));
            }
            else if (count >= limite1Star_inf && count <= limite1Star_sup)
            {
                lvlObjects.AsignarEstrellas(posLvl, 1);
                star1.SetActive(true);

                StartCoroutine(ShowStars(1));
            }

            else
                StartCoroutine(ShowStars(0));


        }
    }

    private void ShowVictoryPanel()
    {
        CalculateScore(strikeText);

        // Instantiate(obStar, transform.position + offset, Quaternion.identity);

        LevelClearManager.Instance.ShowLevelDialog("Level Cleared", strikeText.text.ToString());
    }

    IEnumerator ShowStars(int stars)
    {
        SaveAndLoad.Save(posLvl, stars);

        star1Rec.DOScale(Vector3.zero, 0);
        star2Rec.DOScale(Vector3.zero, 0);
        star3Rec.DOScale(Vector3.zero, 0);

        if (stars >= 2)
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
}
