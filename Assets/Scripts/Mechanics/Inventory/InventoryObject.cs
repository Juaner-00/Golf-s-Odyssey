using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "new Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private string savePath;
    [SerializeField] private ItemDBObject database;
    [SerializeField] private List<InventorySlot> container = new List<InventorySlot>();

    public event OnInventoryEvent OnChange;
    public delegate void OnInventoryEvent();


    public void AddItem(ItemObject item, AvailableType available)
    {
        foreach (InventorySlot slot in container)
            if (slot.ID == item.ID)
                return;

        SetEmptySlot(item, available);

        // Activar el evento
        OnChange?.Invoke();
    }

    private void SetEmptySlot(ItemObject item, AvailableType available)
    {
        container.Add(new InventorySlot(item, item.ID, available));
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
        container = new List<InventorySlot>();
    }

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        foreach (InventorySlot slot in container)
            slot.Item = database.IDItems[slot.ID];
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
            List<InventorySlot> newContainer = (List<InventorySlot>)formatter.Deserialize(stream);
            for (int i = 0; i < container.Count; i++)
                container[i].UpdateSlot(newContainer[i].Item, newContainer[i].ID, newContainer[i].Available);
            stream.Close();

            OnChange?.Invoke();
        }
    }


    #endregion

    // Accesores
    public List<InventorySlot> Container { get => container; }
    public ItemDBObject Database { get => database; }
}

public enum AvailableType
{
    Disable,
    Enable
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
