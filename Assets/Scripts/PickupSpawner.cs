using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawnables;
    public float spawnTimeMax;
    public float spawnTimeMin;
    private float spawnTime;
    private int randomInd;
    private bool stop;
    public bool isSpawned;
    private GameObject spawnedObject;
    public bool forceSpawn;

    void Start()
    {
        spawnedObject = null;
        spawnTimeMax = 20f;
        spawnTimeMin = 5f;
        isSpawned = false;
        stop = false;
        StartCoroutine(waitSpawner());
    }
    // Update is called once per frame
    void Update()
    {

        isSpawned = spawnedObject != null;
        if (forceSpawn) spawnObject(Random.Range(0,2));
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
    }
    void spawnObject(int index)
    {
        if (!isSpawned || (!isSpawned && forceSpawn))
        {
            spawnedObject = Instantiate(spawnables[index], this.transform);
            forceSpawn = false;
            isSpawned = true;
        }
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(Random.Range(5f,10f));
        while(!stop)
        {
            yield return new WaitForSeconds(spawnTime);
            randomInd = Random.Range(0, 2);
            spawnObject(randomInd);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
