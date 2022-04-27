using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float timeToSpawn;
    private float currentTimeToSpawn;
    private int cointCount; 
    // Start is called before the first frame update
    void Start()
    {
        currentTimeToSpawn = timeToSpawn;
        cointCount = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime; 
        }
        else
        {
            Spawn();
            currentTimeToSpawn = timeToSpawn; 
        }
    }
    public void Spawn()
    {
        //stops spawning if there are more than 10 coins in the scene
        if (cointCount > 10)
            return;
        cointCount += 1; 
        Instantiate(objectToSpawn, transform.position, transform.rotation); 
    }
}
