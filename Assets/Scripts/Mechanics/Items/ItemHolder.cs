using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] private ItemObject item;
    [SerializeField] private int amount = 1;

    public ItemObject Item { get => item; }
    public int Amount { get => amount; set => amount = value; }
}
