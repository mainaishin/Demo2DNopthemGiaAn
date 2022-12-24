using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    public Transform[] spawnPos;

    void Start()
    {
        StartCoroutine(SpawnRandomGameObject());
    }

    IEnumerator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(Random.Range(0, 1.1f));

        int randEnemy = Random.Range(0, enemyPrefab.Length);
        int randPoint = Random.Range(0, spawnPos.Length);

        
        Instantiate(enemyPrefab[randEnemy], spawnPos[randPoint].position,transform.rotation);

        StartCoroutine(SpawnRandomGameObject()); 
    }
}
