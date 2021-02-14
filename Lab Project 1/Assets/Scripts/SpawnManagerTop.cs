using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerTop : MonoBehaviour
{

    public GameObject[] obstaclePrefabsTop;
    public GameObject[] obstaclePrefabsSides;

    public float spawnLimitXleft = -15f;
    public float spawnLimitXright = 15f;
    public float spawnLimitZtop = 11.05f;
    public float spawnLimitZbottom = 3.7f;

    private float spawnPosY = 10.0f;
    private float spawnPosZ = 12f;

    public float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Begin spawning obstacels from the top of the screen between every 3-5 seconds
        InvokeRepeating("SpawnFromTop", startDelay, Random.Range(2.0f, 5.0f));
        InvokeRepeating("SpawnFromSides", startDelay, Random.Range(2.0f, 4.0f));
    }

    // Update is called once per frame
    void SpawnFromTop()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXleft, spawnLimitXright), spawnPosY, spawnPosZ);

        int obstacleIndex = Random.Range(0, obstaclePrefabsTop.Length);

        Instantiate(obstaclePrefabsTop[obstacleIndex], spawnPos, obstaclePrefabsTop[0].transform.rotation);
    }
    
    void SpawnFromSides()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabsSides.Length);
        
        //Randomly chooses the side to spawn the bird prefabs on
        if (Random.Range(0, 2) >= 1 )
        {
            Vector3 spawnPos = new Vector3(14.5f, spawnPosY, Random.Range(spawnLimitZtop, spawnLimitZbottom));


            Instantiate(obstaclePrefabsSides[0], spawnPos, obstaclePrefabsSides[0].transform.rotation);
        }
        else
        {
            Vector3 spawnPos = new Vector3(-14.5f, spawnPosY, Random.Range(spawnLimitZtop, spawnLimitZbottom));


            Instantiate(obstaclePrefabsSides[1], spawnPos, obstaclePrefabsSides[1].transform.rotation);
        }
    }
}
