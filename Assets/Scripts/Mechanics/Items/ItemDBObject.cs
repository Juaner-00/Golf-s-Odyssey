using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDBObject : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private ItemObject[] items;
    private Dictionary<int, ItemObject> idItems = new Dictionary<int, ItemObject>();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].ID = i;
            idItems.Add(i, items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        idItems = new Dictionary<int, ItemObject>();
    }

    public ItemObject[] Items { get => items; }
    public Dictionary<int, ItemObject> IDItems { get => idItems; }
}