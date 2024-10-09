using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private int pickupCountMin = 2;
    [SerializeField] private GameObject[] spawners;
    private int pickupCount = 0;
    private PickupSpawner curr;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        pickupCount = 0;
        foreach(GameObject spawner in spawners)
        {
            curr= spawner.GetComponent<PickupSpawner>();
            if(curr.isSpawned) pickupCount++;
        }

        if(pickupCount < pickupCountMin)
        {
            int i = Random.Range(0, 9);
            curr = spawners[i].GetComponent<PickupSpawner>();
            curr.forceSpawn = true;
        }
    }
}
