using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectIfActive : MonoBehaviour
{
    public GameObject other2Activate;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf) other2Activate.SetActive(true);
    }
}
