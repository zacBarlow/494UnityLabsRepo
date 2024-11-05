using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Items")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string dName;
    public Sprite picture;
    public GameObject prefab;
}
