using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float timeBetweeenSpawns;
    float nextSpawnTime;

    public GameObject enemy;

    public Transform[] spawnPoints;

    void Update()
    {
        if (Time.time > nextSpawnTime){
            nextSpawnTime = Time.time + timeBetweeenSpawns;
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, randomSpawnPoint.position, Quaternion.identity);
        }
    }
}
