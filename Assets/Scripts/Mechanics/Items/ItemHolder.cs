using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] private ItemObject item;

    public ItemObject Item { get => item; }
}
