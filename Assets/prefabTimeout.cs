using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabTimeout : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;

    // Update is called once per frame
    void Update()
    {
        prefab1.SetActive(false);
        prefab2.SetActive(false);
    }
}
