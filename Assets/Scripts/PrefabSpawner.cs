using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject gameObjectToSpawn;

    private float timeSinceLastSpawn = 0f;
    
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        
        // todo replace this with a coroutine
        if (timeSinceLastSpawn > spawnRate)
        {
            timeSinceLastSpawn = 0f;
            Instantiate(gameObjectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
