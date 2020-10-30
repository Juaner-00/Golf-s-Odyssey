using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject UIMenu;
    [SerializeField] GameObject SafeZone;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject DialogMenu;
    [SerializeField] GameObject LoadingMenu;

    [SerializeField] Ease easeIn;
    public Ease easeOut;
    public float time;

    RectTransform UIRec, SafeZoneRec, PauseRec, DialogRec, LoadingRec;

    public static MenuManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        if (UIMenu != null)
            UIRec = UIMenu.GetComponent<RectTransform>();
        if (SafeZone != null)
            SafeZoneRec = SafeZone.GetComponent<RectTransform>();
        if (PauseMenu != null)
            PauseRec = PauseMenu.GetComponent<RectTransform>();
        if (DialogMenu != null)
            DialogRec = DialogMenu.GetComponent<RectTransform>();
        if (LoadingMenu != null)
            LoadingRec = LoadingMenu.GetComponent<RectTransform>();
    }

    public void OpenUI()
    {
        Activate(false, true, false, false);
    }

    public void OpenPause()
    {
        Activate(true, false, false, false);
    }

    public void OpenDialog()
    {
        Activate(false, false, true, false);
    }

    public void OpenLoading()
    {
        Activate(false, false, false, true);
    }

    public void CloseLoading()
    {
        LoadingRec.DOAnchorPosX(900, 0.2f);
        LoadingMenu.SetActive(false);
    }

    private void Activate(bool pause, bool ui, bool dialog, bool loading)
    {
        if (PauseMenu != null)
        {
            if (pause)
            {
                PauseMenu.SetActive(pause);
                PauseRec.DOScale(Vector3.zero, 0);
                PauseRec.DOScale(Vector3.one, time).SetEase(easeOut);
            }
            else if (PauseMenu.activeInHierarchy)
            {
                StartCoroutine("DesactivatePause");
            }
        }
        if (UIMenu != null)
        {
            if (ui)
            {
                UIMenu.SetActive(ui);
                UIRec.DOScale(Vector3.zero, 0);
                SafeZone.SetActive(ui);
                SafeZoneRec.DOScale(Vector3.zero, 0);
                UIRec.DOScale(Vector3.one, time * 2f).SetEase(easeOut);
                SafeZoneRec.DOScale(Vector3.one, time * 2).SetEase(easeOut);
            }
            else if (UIMenu.activeInHierarchy)
            {
                StartCoroutine("DesactivateUI");
            }
        }
        if (DialogMenu != null)
        {
            if (dialog)
            {
                DialogMenu.SetActive(dialog);
                DialogRec.localScale = Vector3.zero;
                // DialogRec.DOScale(Vector3.zero, 0);
                DialogRec.DOScale(Vector3.one, time * 1.5f).SetEase(easeOut);
            }
        }
        if (LoadingMenu != null)
        {
            LoadingMenu.SetActive(loading);
            // LoadingRec.DOMoveX(0, 0.25f);
            LoadingRec.DOAnchorPosX(0, 0.25f);
        }
    }

    IEnumerator DesactivatePause()
    {
        PauseRec.DOScale(Vector3.zero, time).SetEase(easeIn);
        yield return new WaitForSeconds(time);
        PauseMenu.SetActive(false);
    }

    IEnumerator DesactivateUI()
    {
        UIRec.DOScale(Vector3.zero, time / 2).SetEase(easeIn);
        SafeZoneRec.DOScale(Vector3.zero, time / 2).SetEase(easeIn);
        yield return new WaitForSeconds(time / 2);
        UIMenu.SetActive(false);
        SafeZone.SetActive(false);
    }
}

