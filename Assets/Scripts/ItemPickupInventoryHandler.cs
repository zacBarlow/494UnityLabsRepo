using NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupInventoryHandler : MonoBehaviour
{

    [SerializeField] private InventoryItemData indat;
    [SerializeField] private InventoryManager inMan;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inMan.Add(indat);
            Destroy(this.gameObject);
        }
    }
}
