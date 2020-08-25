using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryObject inventory;

    public InventoryObject Inventory { get => inventory; }
}
