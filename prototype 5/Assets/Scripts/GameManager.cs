using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //creates a list, NOT an Array. 
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public bool isGameActive;
    public Button resetButton;

    public GameObject titleScreen;

    void Start()
    {

    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive == true)
        {
            yield return new WaitForSeconds(spawnRate);
            //randomly chooses a number from the list that was set up
            int index = Random.Range(0, targets.Count);
            //instantiates from the list
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        //Long version of this is score = score + scoreToAdd, below is shorthand
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        resetButton.gameObject.SetActive(true);
    }

   public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        UpdateScore(0);
        isGameActive = true;
        scoreText.text = "Score: " + score;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
    }
}
