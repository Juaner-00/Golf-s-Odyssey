using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject UIMenu;
    [SerializeField] GameObject InventoryMenu;
    [SerializeField] GameObject PauseMenu;

    private static MenuManager instance;
    public static MenuManager Instance { get => instance; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void OpenInventory()
    {
        PauseMenu.SetActive(false);
        UIMenu.SetActive(false);
        InventoryMenu.SetActive(true);
    }

    public void OpenUI()
    {
        PauseMenu.SetActive(false);
        UIMenu.SetActive(true);
        InventoryMenu.SetActive(false);
    }

    public void OpenPause()
    {
        PauseMenu.SetActive(true);
        UIMenu.SetActive(false);
        InventoryMenu.SetActive(false);
    }
}

