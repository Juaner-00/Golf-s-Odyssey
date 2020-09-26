using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject UIMenu;
    [SerializeField] GameObject InventoryMenu;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject DialogMenu;
    [SerializeField] GameObject LoadingMenu;

    RectTransform UIRec, InvRec, PauseRec, DialogRec, LoadingRec;

    private static MenuManager instance;
    public static MenuManager Instance { get => instance; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        if (UIMenu != null)
            UIRec = UIMenu.GetComponent<RectTransform>();
        if (InventoryMenu != null)
            InvRec = InventoryMenu.GetComponent<RectTransform>();
        if (PauseMenu != null)
            PauseRec = PauseMenu.GetComponent<RectTransform>();
        if (DialogMenu != null)
            DialogRec = DialogMenu.GetComponent<RectTransform>();
        if (LoadingMenu != null)
            LoadingRec = LoadingMenu.GetComponent<RectTransform>();
    }

    public void OpenInventory()
    {
        Activate(false, false, true, false, false);
    }

    public void OpenUI()
    {
        Activate(false, true, false, false, false);
    }

    public void OpenPause()
    {
        Activate(true, false, false, false, false);
    }

    public void OpenDialog()
    {
        Activate(false, false, false, true, false);
    }

    public void OpenLoading()
    {
        Activate(false, false, false, false, true);
    }

    public void CloseLoading()
    {
        LoadingRec.DOAnchorPosX(900, 0.2f);
        LoadingMenu.SetActive(false);
    }

    private void Activate(bool pause, bool ui, bool inventory, bool dialog, bool loading)
    {
        if (PauseMenu != null)
            PauseMenu.SetActive(pause);
        if (UIMenu != null)
            UIMenu.SetActive(ui);
        if (InventoryMenu != null)
            InventoryMenu.SetActive(inventory);
        if (DialogMenu != null)
            DialogMenu.SetActive(dialog);
        if (LoadingMenu != null)
        {
            LoadingMenu.SetActive(loading);
            LoadingRec.DOAnchorPosX(0, 0.25f);
        }
    }
}

