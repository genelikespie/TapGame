﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {


    ActiveTapGOPool activeEnemyPool;
    TapGOPool enemyPool;
    public List<Transform> spawnPoints;

    // placeholder for target transform, replace this with dynamic implementation
    public Transform target;
	// Use this for initialization
    void Awake()
    {
        spawnPoints = new List<Transform>();
        activeEnemyPool = TapGOPoolSingleton<Enemy>.ActivePoolInstance();
        enemyPool = TapGOPoolSingleton<Enemy>.PoolInstance();
        if (!activeEnemyPool || !enemyPool)
            Debug.LogError("Cannot find activeEnemyPool!");

        foreach (Transform t in transform.GetComponentsInChildren<Transform>())
        {
            if (t.tag == "Spawner")
                spawnPoints.Add(t);
        }
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S)) {
            int i = (int)(Random.value * (spawnPoints.Count - 1));
            Enemy enemy = enemyPool.GetObject().GetComponent<Enemy>();
            if (!enemy) Debug.LogError("enemy not found");
            enemy.transform.position = spawnPoints[i].position;
            enemy.transform.rotation = spawnPoints[i].rotation;

            // set enemy target
            enemy.target = target;
            enemy.gameObject.SetActive(true);
        }
	}
}
