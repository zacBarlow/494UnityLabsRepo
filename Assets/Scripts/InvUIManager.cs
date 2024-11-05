using NPC;
using Player;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InvUIManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inMan;
    private List<InventoryItem> invItems = new List<InventoryItem>();
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject InvPanel;
    [SerializeField] private Sprite defSprite;
    [SerializeField] private ItemPickupHealthbarInteract HealthBar;
    private bool toggled = false;

    public void InventoryToggleButton()
    {
        if (!toggled)
        {
            toggled = true;
            InvPanel.SetActive(true);
            FillInventory();
        }
        else
        {
            toggled = false;
            InvPanel.SetActive(false);

        }
    }
    public void FillInventory()
    {
        foreach(GameObject b in buttons)
        {
            b.SetActive(false);
        }
        invItems.Clear();
        int i = 0;
        foreach (InventoryItem item in inMan.inventory)
        {
            invItems.Add(item);
            buttons[i].SetActive(true);
            buttons[i].GetComponent<Image>().sprite = item.data.picture;
            buttons[i].GetComponentInChildren<TMP_Text>().text = item.data.dName;
            i++;
        }
    }
    public void InventoryPress(int index)
    {
        
        if (invItems[index].data.dName == "HealthPack")
        {
            HealthBar.InventoryHeal();
        }
        if( invItems[index].data.id == "inv_book")
        {

        }else
        {
            inMan.Remove(invItems[index].data);
            invItems.Remove(invItems[index]);
        }
        
        FillInventory();
    }
}
