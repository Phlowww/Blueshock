using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class SpawnManager : NetworkBehaviour
{

    private int enemiesToSpawn;
    public GameObject[] spawnPoints;
    public NetworkManager networkManager;
    public GameObject enemy;
    public NetworkObject enemyNetworkObject;
    public int numberOfEnemies;

    
    // Start is called before the first frame update
    void Start()
    {
        enemiesToSpawn = numberOfEnemies;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        SpawnClientRpc();
    }


    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindWithTag("Enemy"))
        {
            enemiesToSpawn += 5;
            //GameManager.Instance.NextWave();
            SpawnClientRpc();
        }
    }

    [ClientRpc]
    private void SpawnClientRpc()
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
