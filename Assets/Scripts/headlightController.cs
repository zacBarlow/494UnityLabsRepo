using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class headlightController : MonoBehaviour
{

    public GameObject headlight;
    public GameObject tooltip;
    private bool tooltipVis = false;
    private bool state = false;
    
    void Start()
    {
        tooltip.SetActive(true);
        headlight.SetActive(state);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            state = !state;
            headlight.SetActive(state);
            tooltip.SetActive(tooltipVis);
        }        
    }
}
