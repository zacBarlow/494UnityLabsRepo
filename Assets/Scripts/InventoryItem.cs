using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public InventoryItemData data { get; private set; }
    public InventoryItem(InventoryItemData dat)
    {
        data = dat;
    }
}
