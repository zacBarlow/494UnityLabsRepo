using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
namespace Player
{
    public class ItemPickupHealthbarInteract : MonoBehaviour
    {
        private int barsInd = 3;
        public GameObject[] bars;
        public GameObject fullHealthPrompt;
        public GameObject lowHealthPrompt;
        public GameObject deathMessage;

        private void Start()
        {
            barsInd = 3;

        }
        private void OnTriggerStay(Collider other)
        {
            GameObject otherO = other.gameObject;
            if (otherO.CompareTag("bomb"))
            {
                if (barsInd == 0)
                {
                    deathMessage.SetActive(true);
                }
                else if (barsInd == 1)
                {
                    bars[barsInd--].SetActive(false);
                    lowHealthPrompt.SetActive(true);
                    StartCoroutine(promptTimer(lowHealthPrompt));
                }
                else if (barsInd == 3)
                {
                    fullHealthPrompt.SetActive(false);
                    bars[barsInd--].SetActive(false);
                }
                else
                {
                    bars[barsInd--].SetActive(false);
                }
                Destroy(otherO);
            }
            if (otherO.CompareTag("symbol_+"))
            {
                if (barsInd == 3)
                {
                    fullHealthPrompt.SetActive(true);
                    StartCoroutine(promptTimer(fullHealthPrompt));
                }
                else if (barsInd == 0)
                {
                    lowHealthPrompt.SetActive(false);
                    bars[++barsInd].SetActive(true);
                }
                else
                {
                    bars[++barsInd].SetActive(true);

                }
                Destroy(otherO);

            }

        }
        public bool InventoryHeal()
        {
            if (barsInd == 3)
            {
                fullHealthPrompt.SetActive(true);
                StartCoroutine(promptTimer(fullHealthPrompt));
                return false;
            }
            else if (barsInd == 0)
            {
                lowHealthPrompt.SetActive(false);
                bars[++barsInd].SetActive(true);
            }
            else
            {
                bars[++barsInd].SetActive(true);
            }
            return true;
        }
        IEnumerator promptTimer(GameObject prompt)
        {
            yield return new WaitForSeconds(4);
            prompt.SetActive(false);
            StopCoroutine(promptTimer(prompt));
        }

    }
}
