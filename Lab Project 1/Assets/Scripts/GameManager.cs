using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    //StartVariables associated with spawning obstacles
    public List<GameObject> obstaclePrefab;
    private PlayerController player;
    private float spawnLimitXleft = -15f, spawnLimitXright = 15f, spawnLimitZtop = 15f, spawnLimitZbottom = 3.7f, spawnPosZ = 12f, spawnPosY = 10.0f;
    public float startDelay = 1.0f;

    public bool isGameActive;

    public TextMeshProUGUI lifeCounterText, resetButtonText, gameOverText, scoreText;
    public GameObject titleMenu;
    private int score;
    public int lifeCounter;

    private float spawnRate = 4;

    public Button resetButton;

    //controls the spawn rate of obstacles
    IEnumerator SpawnObstacles()
    {
        while(isGameActive == true)
        {
            yield return new WaitForSeconds(spawnRate);           
            SpawnFromTop();
            SpawnFromSides();            
        }
    }

    //adds points for being alive
    IEnumerator TimeAliveScore()
    {
        while(isGameActive == true)
        {
            yield return new WaitForSeconds(1);
            UpdateScore(1);
        }
    }
    void SpawnFromTop()
    {
        //random spawns for obstacles at the top
        Vector3 spawnPos1 = new Vector3(Random.Range(spawnLimitXleft, spawnLimitXright), spawnPosY, spawnPosZ);
        Quaternion newRotation = Quaternion.Euler(new Vector3(-90, 180, 0));
        Instantiate(obstaclePrefab[1], spawnPos1, newRotation);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXleft, spawnLimitXright), spawnPosY, spawnPosZ);
        Instantiate(obstaclePrefab[0], spawnPos, obstaclePrefab[0].transform.rotation);
    }

    void SpawnFromSides()
    {
        int spawnSide = Random.Range(0, 2);

        //Randomly chooses the side to spawn the bird prefabs on
        if (spawnSide >= 1)
        {
            Quaternion newRotation = Quaternion.Euler(new Vector3(0, -90,0 ));
            Vector3 spawnPos = new Vector3(14.5f, spawnPosY, Random.Range(spawnLimitZtop, spawnLimitZbottom));

            obstaclePrefab[2].tag = "Left";

            Instantiate(obstaclePrefab[2], spawnPos, newRotation);
        }
        else
        {
            Vector3 spawnPos = new Vector3(-14.5f, spawnPosY, Random.Range(spawnLimitZtop, spawnLimitZbottom));

            obstaclePrefab[2].tag = "Right";

            Instantiate(obstaclePrefab[2], spawnPos, obstaclePrefab[2].transform.rotation);
        }
    }
    //pulls from obstaclemove script to add to score
    public void UpdateScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLife(int lifeLost)
    {
        lifeCounter += lifeLost;
        lifeCounterText.text = "Life: " + lifeCounter;
    }

    public void GameOver()
    {
        if(lifeCounter == 0)
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            isGameActive = false;
            gameOverText.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
            resetButtonText.text = "Reset";
            player.GameOverDestroy();
        }

    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        UpdateScore(0);
        UpdateLife(0);
        isGameActive = true;
        titleMenu.gameObject.SetActive(false);
        spawnRate /= difficulty;
        StartCoroutine(SpawnObstacles());
        StartCoroutine(TimeAliveScore());
    }
}
