﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject enemy;
	public float spawnRate = 1;

	void Start() {
		InvokeRepeating("SpawnEnemies", spawnRate, spawnRate);
	}

	void SpawnEnemies() {
		int randomIndex = Random.Range(0, spawnPoints.Length);

        for(var i = 0; i < spawnPoints.Length; i++) {
            if (i != randomIndex) {
                Instantiate(enemy, spawnPoints[i].position, Quaternion.identity);
			}
		}
	}
}
