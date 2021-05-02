using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;

    void Start()
    {
        //grabs button that was clicked
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        //applies the buttons value to the difficulty equations in GameManager
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}
