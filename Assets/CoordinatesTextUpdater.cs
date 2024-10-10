using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;
using System;

public class CoordinatesTextUpdater : MonoBehaviour
{
    [SerializeField] public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.transform.position.x;
        float z = player.transform.position.z;
        float y = player.transform.rotation.y;
        StringBuilder temp = new StringBuilder();
        temp.Append("X:").Append(Math.Round(x, 2, MidpointRounding.ToEven)).Append("\nZ:");
        temp.Append(Math.Round(z, 2, MidpointRounding.ToEven)).Append("\nY:").Append(Math.Round((y*180), 0, MidpointRounding.ToEven));
        this.gameObject.GetComponent<TMP_Text>().text = temp.ToString();
    } 

}
