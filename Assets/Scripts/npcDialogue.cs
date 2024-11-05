using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;
using System;

namespace NPC { 
    public class npcDialogue : MonoBehaviour
    {

        [SerializeField] private GameObject NPCTextHolder;
        [SerializeField] private bool player_nearby;
        [SerializeField] private GameObject playerdialoguePanel;
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private GameObject PlayerPanelText;
        [SerializeField] private GameObject PanelText;
        [SerializeField] private GameObject dialoguePrompt;
        [SerializeField] private InventoryManager inMan;
        [SerializeField] private InventoryItemData bookDat;
        private int dialogueState = 0;
        private int playerDial = 0;
        private int NPCDial = 0;
        [SerializeField] private bool hasBook;
        private bool dialogueTurn = false;

        /*
         * Dialogue States:
         *  0: book not found, will reset conversation upon exiting NPC range.
         *  1: book found and dialogue started but not given over, will reset conversation
         *  2: book handed over and dialogue finished/started.  Will not reset conversation
         * hasBook: calls InventoryManager from player to check if they have the book in their inventory.
         * (NPC/Player)Dial:stores which element from respective lists to put into dialogue text boxes.
         */

        // Start is called before the first frame update
        void Start()
        {
            dialoguePanel.SetActive(false);
            playerdialoguePanel.SetActive(false);
            PlayerPanelText.SetActive(false);
            PanelText.SetActive(false);
            dialoguePrompt.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (player_nearby && Input.GetKeyDown(KeyCode.E))
            {
                StringBuilder temp = new StringBuilder();
                if (this.gameObject.CompareTag("NPC"))
                {
                    dialoguePanel.SetActive(true);
                    PanelText.SetActive(true);
                    temp.Append(NPCTextHolder.GetComponent<NPCText>().ReturnNPCDialogue(-1));
                    PanelText.GetComponent<TMP_Text>().text = temp.ToString();
                }
                else
                {
                    
                    dialoguePanel.SetActive(true);

                    PanelText.SetActive(true);
                    if (dialogueTurn)
                    {
                        playerdialoguePanel.SetActive(true);
                        PlayerPanelText.SetActive(true);
                        if (dialogueState == 0 && playerDial > 0) playerDial = 0; 
                        temp.Append(NPCTextHolder.GetComponent<NPCText>().ReturnPDialogue(playerDial));
                        PlayerPanelText.GetComponent<TMP_Text>().text = temp.ToString();
                        playerDial++;
                        if (playerDial > 3) { playerDial = 3;dialogueState = 2; }
                    }
                    else
                    {
                        if (dialogueState == 0 && NPCDial > 1) NPCDial = 1; 
                        temp.Append(NPCTextHolder.GetComponent<NPCText>().ReturnNPCDialogue(NPCDial));
                        PanelText.GetComponent<TMP_Text>().text = temp.ToString();
                        NPCDial++;
                        if(NPCDial ==4 && playerDial == 2) { inMan.Remove(bookDat); }
                        if (NPCDial > 5) { NPCDial = 5; dialogueState = 2; }
                    }
                    dialogueTurn = !dialogueTurn;
                }
            }
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                dialoguePrompt.SetActive(true);
                player_nearby = true;
                hasBook = collider.gameObject.GetComponent<InventoryManager>().HasBook();
                
                if (dialogueState == 0)
                {
                    if (hasBook)
                    {
                        dialogueState = 1;
                        playerDial = 1; NPCDial = 2;
                    }
                }
                else if (dialogueState == 1)
                {
                    if (!hasBook)
                    {
                        dialogueState = 2;
                        playerDial = 3; NPCDial = 4;
                    }
                }
                else dialogueState = 2;
                
               
                
            }
          
        }
        private void OnTriggerExit(Collider other)
        {
            player_nearby=false;
            dialoguePrompt.SetActive(false);
            playerdialoguePanel.SetActive(false);
            PlayerPanelText.SetActive(false);
            PanelText.SetActive(false);
            dialoguePanel.SetActive(false);
            if(dialogueState == 0)
            {
                playerDial = 0;NPCDial = 0;
            }
            else if (dialogueState == 1)
            {
                playerDial = 1;NPCDial = 2;
            }
            else
            {
                playerDial = 3; NPCDial = 5;
            }
        }
    }
}