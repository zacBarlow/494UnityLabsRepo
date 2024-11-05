using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NPC
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private GameObject bookRef;
        private Dictionary<InventoryItemData, InventoryItem> itemDict;
        public List<InventoryItem> inventory{get;private set;}
        // Start is called before the first frame update
        private void Awake()
        {
            inventory = new List<InventoryItem>();
            itemDict = new Dictionary<InventoryItemData, InventoryItem>();
        }
        public InventoryItem Get(InventoryItemData data)
        {
            if(itemDict.TryGetValue(data,out InventoryItem value))
            {
                return value;
            }
            return null;
        }
        public void Add(InventoryItemData data)
        {
            if(itemDict.TryGetValue(data,out InventoryItem value))
            {

            }
            else
            {
                InventoryItem item = new InventoryItem(data);
                inventory.Add(item);
                itemDict.Add(data, item);
            }
        }

        public void Remove(InventoryItemData data)
        {
            if(itemDict.TryGetValue(data, out InventoryItem value))
            {
                inventory.Remove(value);
                itemDict.Remove(data);
            }
  
        }
        public bool HasBook()
        {
            if (bookRef != null) return false;
            return true;
        }

    }
}
