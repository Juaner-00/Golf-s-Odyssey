using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Default Prop", menuName = "Inventory System/Prop")]
public class ItemObject : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private Sprite uiDisplay;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int cost;
    [TextArea(15, 10), SerializeField] private string description;

    public int ID { get => id; set => id = value; }
    public Sprite UIDisplay { get => uiDisplay; }
    public GameObject Prefab { get => prefab; }
    public int Cost { get => cost; }
    public string Description { get => description; }
}