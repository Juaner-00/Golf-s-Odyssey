using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject UIMenu;
    [SerializeField] GameObject InventoryMenu;

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
        UIMenu.SetActive(false);
        InventoryMenu.SetActive(true);
    }

    public void OpenUI()
    {
        UIMenu.SetActive(true);
        InventoryMenu.SetActive(false);
    }
}

