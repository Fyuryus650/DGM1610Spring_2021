using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    public int waveNumber = 1;
    public int enemyCount;
    public GameObject powerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //spawns an enemy to begin game
        SpawnEnemyWave(waveNumber);
        
        //Create powerup prefab
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    void Update()
    {
        //counts how many enemies are in play at the moment
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //if enemy count gets to zero add 1 to wave and spawn more enemies based on the wave
        if(enemyCount == 0)
        {
            //adds 1 to wave number and spawns based on waves
            waveNumber ++;
            SpawnEnemyWave(waveNumber);

            //Creates additional powerup prefabs for player to collect
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
