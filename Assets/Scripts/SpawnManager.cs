using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private int enemiesToSpawn;
    public GameObject[] spawnPoints;
    public GameObject enemy;
    public int numberOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        enemiesToSpawn = numberOfEnemies;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindWithTag("Enemy"))
        {
            enemiesToSpawn += 5;
            //GameManager.Instance.NextWave();
            Spawn();
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int j = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy,
                spawnPoints[j].transform.position,
                spawnPoints[j].transform.rotation);
        }
    }
}
