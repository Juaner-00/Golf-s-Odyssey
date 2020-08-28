using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class DisplayInventory : MonoBehaviour
{
    private MouseItem mouseItem = new MouseItem();

    [SerializeField] private GameObject inventoryPrefab;
    [SerializeField] private InventoryObject inventory;
    [SerializeField] private int xStart;
    [SerializeField] private int yStart;
    [SerializeField] private int xSpaceBetweenItems;
    [SerializeField] private int ySpaceBetweenItems;
    [SerializeField] private int numberOfColumns;

    private Dictionary<GameObject, InventorySlot> itemsDisplay = new Dictionary<GameObject, InventorySlot>();

    #region DISPLAY

    public void Start()
    {
        inventory.OnChange += UpdateDisplay;

        CreateSlots();
    }

    public void UpdateDisplay()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> slot in itemsDisplay)
        {
            slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.Database.IDItems[slot.Value.ID].UIDisplay;

            if (slot.Value.Available == AvailableType.Enable)
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                slot.Key.GetComponent<Button>().interactable = true;
            }
            else
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(0.8f, 0.8f, 0.8f, 0.8f);
                slot.Key.GetComponent<Button>().interactable = false;
            }
        }
    }

    private void CreateSlots()
    {
        itemsDisplay = new Dictionary<GameObject, InventorySlot>();

        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            obj.GetComponent<Button>().onClick.AddListener(delegate { ButtonOnClick(obj); });

            itemsDisplay.Add(obj, inventory.Container[i]);
        }
        UpdateDisplay();
    }

    #endregion

    private Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + xSpaceBetweenItems * (i % numberOfColumns), yStart - ySpaceBetweenItems * (i / numberOfColumns), 0f);
    }

    #region BUTTON_ACTIONS

    private void ButtonOnClick(GameObject obj)
    {
        BuildingPlacement.Instance.InstanciateObject(itemsDisplay[obj].Item.Prefab);
        MenuManager.Instance.OpenUI();
    }

    #endregion

}

public class MouseItem
{
    private GameObject obj;

    public GameObject Obj { get => obj; set => obj = value; }
}