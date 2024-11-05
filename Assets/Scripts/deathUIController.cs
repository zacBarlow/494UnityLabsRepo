using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathUIController : MonoBehaviour
{

    public GameObject DeathPanel;
    public GameObject[] UIElementsToOverride;
    public GameObject currentPlayer;

    // Update is called once per frame
    void Update()
    {

        if(DeathPanel.activeSelf)
        {
            currentPlayer.SetActive(false);
            foreach (GameObject g in UIElementsToOverride)
            {
                g.SetActive(false);
            }
        }
    }

}
