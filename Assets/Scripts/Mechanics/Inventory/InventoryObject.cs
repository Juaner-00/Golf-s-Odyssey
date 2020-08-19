using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "new Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    [SerializeField] private string savePath;
    [SerializeField] private ItemDBObject database;
    [SerializeField] private int maxCapacity;
    [SerializeField] private Inventory container;

    public event OnInventoryEvent OnChange;
    public delegate void OnInventoryEvent();

    private int countObj;


    public void AddItem(ItemObject item, AvailableType available)
    {
        foreach (InventorySlot slot in container.Items)
            if (slot.ID == item.ID)
                return;

        SetEmptySlot(item, available);

        // Activar el evento
        OnChange?.Invoke();
    }

    private InventorySlot SetEmptySlot(ItemObject item, AvailableType available)
    {
        foreach (InventorySlot slot in container.Items)
            if (slot.ID <= -1)
            {
                slot.UpdateSlot(item, item.ID, available);
                return slot;
            }
        return null;
    }

    public bool CanAddItem(ItemObject item)
    {
        // Puede añadir un item si hay un espacio libre
        if (countObj < maxCapacity)
            return true;
        // Ver si tiene el objeto
        else
            foreach (InventorySlot slot in container.Items)
                if (slot.Item.ID == item.ID)
                    return true;

        // Si no hay espacio o ningún objeto igual
        return false;
    }

    public void MoveItem(InventorySlot slot1, InventorySlot slot2)
    {
        InventorySlot temp = new InventorySlot(slot2.Item, slot2.ID, slot2.Available);
        slot2.UpdateSlot(slot1.Item, slot1.ID, slot1.Available);
        slot1.UpdateSlot(temp.Item, temp.ID, temp.Available);
        OnChange?.Invoke();
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        container = new Inventory(maxCapacity);
        countObj = 0;
    }

    #region LOAD/SAVE   

    [ContextMenu("Save")]
    public void Save()
    {
        // string saveData = JsonUtility.ToJson(this, true);
        // BinaryFormatter bf = new BinaryFormatter();
        // FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        // bf.Serialize(file, saveData);
        // file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, container);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            // BinaryFormatter bf = new BinaryFormatter();
            // FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            // JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            // file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < container.Items.Length; i++)
                container.Items[i].UpdateSlot(newContainer.Items[i].Item, newContainer.Items[i].ID, newContainer.Items[i].Available);
            stream.Close();

            OnChange?.Invoke();
        }
    }

    #endregion

    // Accesores
    public Inventory Container { get => container; }
    public ItemDBObject Database { get => database; }
}


[System.Serializable]
public class Inventory
{
    [SerializeField] private InventorySlot[] items = new InventorySlot[4];

    public Inventory(int maxCapacity)
    {
        items = new InventorySlot[maxCapacity];
    }

    public InventorySlot[] Items { get => items; }
}

public enum AvailableType
{
    Enable,
    Disable
}

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private int id;
    [SerializeField] private ItemObject item;
    [SerializeField] private AvailableType available;


    public InventorySlot()
    {
        item = null;
        available = AvailableType.Disable;
        id = -1;
    }

    public InventorySlot(ItemObject item, int id, AvailableType available)
    {
        this.item = item;
        this.available = available;
        this.id = id;
    }

    public void MakeAvailable()
    {
        available = AvailableType.Enable;
    }

    public void UpdateSlot(ItemObject item, int id, AvailableType available)
    {
        this.item = item;
        this.available = available;
        this.id = id;
    }

    public ItemObject Item { get => item; set => item = value; }
    public AvailableType Available { get => available; set => available = value; }
    public int ID { get => id; set => id = value; }
}
