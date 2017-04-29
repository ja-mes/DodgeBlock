using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
	public GameObject[] friends;

	public float friendSpawnProbability = 20;

    public float spawnRate = 1;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", spawnRate, spawnRate);
    }

    void SpawnEnemies()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

		if (Random.value < friendSpawnProbability) {
            int friendRandomIndex = Random.Range(0, friends.Length);
			Instantiate(friends[friendRandomIndex], spawnPoints[randomIndex].position, Quaternion.identity);
		} else {
            Instantiate(enemy, spawnPoints[randomIndex].position, Quaternion.identity);

		}
    }
}
