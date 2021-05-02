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
    public float spawnLimitXleft = -15f;
    public float spawnLimitXright = 15f;
    public float spawnLimitZtop = 15f;
    public float spawnLimitZbottom = 3.7f;
    private float spawnPosY = 10.0f;
    private float spawnPosZ = 12f;
    public float startDelay = 1.0f;

    public bool isGameActive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI lifeCounterText;
    public TextMeshProUGUI resetButtonText;
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
    void SpawnFromTop()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXleft, spawnLimitXright), spawnPosY, spawnPosZ);

        int obstacleIndex = Random.Range(0, 2);

        Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[0].transform.rotation);
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

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
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
    }
}
