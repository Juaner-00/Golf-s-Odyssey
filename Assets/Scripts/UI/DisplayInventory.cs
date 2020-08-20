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

    private Camera cam;

    #region DISPLAY

    public void Start()
    {
        cam = Camera.main;
        inventory.OnChange += UpdateDisplay;

        CreateSlots();
    }

    public void UpdateDisplay()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> slot in itemsDisplay)
        {
            if (slot.Value.ID >= 0)
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.Database.IDItems[slot.Value.Item.ID].UIDisplay;
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
            }

            if (slot.Value.Available == AvailableType.Enable)
                slot.Key.GetComponent<Button>().interactable = true;
            else
                slot.Key.GetComponent<Button>().interactable = false;
        }
    }

    private void CreateSlots()
    {
        itemsDisplay = new Dictionary<GameObject, InventorySlot>();

        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragBegin(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            itemsDisplay.Add(obj, inventory.Container.Items[i]);
        }
    }

    #endregion

    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventrigger = new EventTrigger.Entry();
        eventrigger.eventID = type;
        eventrigger.callback.AddListener(action);
        trigger.triggers.Add(eventrigger);
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + xSpaceBetweenItems * (i % numberOfColumns), yStart - ySpaceBetweenItems * (i / numberOfColumns), 0f);
    }

    #region DRAG_ACTIONS

    private void OnDragBegin(GameObject obj)
    {
        var mouseObj = new GameObject();
        var rt = mouseObj.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(50, 50);
        mouseObj.transform.SetParent(transform.parent);

        if (itemsDisplay[obj].ID >= 0)
        {
            var img = mouseObj.AddComponent<Image>();
            img.sprite = inventory.Database.IDItems[itemsDisplay[obj].ID].UIDisplay;
            img.raycastTarget = false;
            img.preserveAspect = true;
        }
        mouseItem.Obj = mouseObj;
        mouseItem.Slot = itemsDisplay[obj];
    }

    private void OnDrag(GameObject obj)
    {
        if (mouseItem.Obj != null)
            mouseItem.Obj.GetComponent<RectTransform>().position = Input.mousePosition;
    }

    private void OnDragEnd(GameObject obj)
    {
        if (mouseItem.HoverObject)
            inventory.MoveItem(itemsDisplay[obj], itemsDisplay[mouseItem.HoverObject]);
        else
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            GameObject prefab = mouseItem.Slot.Item.Prefab;
            if (prefab)
                Instantiate(prefab, pos, Quaternion.identity);
            UpdateDisplay();
        }

        Destroy(mouseItem.Obj);
        mouseItem.Slot = null;
    }

    private void OnEnter(GameObject obj)
    {
        mouseItem.HoverObject = obj;
        if (itemsDisplay.ContainsKey(obj))
            mouseItem.HoverSlot = itemsDisplay[obj];
    }

    private void OnExit(GameObject obj)
    {
        mouseItem.HoverObject = null;
        mouseItem.HoverSlot = null;
    }

    #endregion

}

public class MouseItem
{
    private GameObject obj;
    private InventorySlot slot;
    private InventorySlot hoverSlot;
    private GameObject hoverObject;

    public GameObject Obj { get => obj; set => obj = value; }
    public InventorySlot Slot { get => slot; set => slot = value; }
    public InventorySlot HoverSlot { get => hoverSlot; set => hoverSlot = value; }
    public GameObject HoverObject { get => hoverObject; set => hoverObject = value; }
}