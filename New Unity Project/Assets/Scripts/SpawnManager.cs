using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    public float startDelay = 2f;
    public float repeatRate = 2f;

    private Vector3 spawnPos = new Vector3(30, 0, 0);

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InvokeRepeating", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void InvokeRepeating()
    {
        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(ObstaclePrefab, spawnPos, ObstaclePrefab.transform.rotation);
        }
    }
}
