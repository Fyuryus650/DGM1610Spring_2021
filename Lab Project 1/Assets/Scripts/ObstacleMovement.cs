using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public int pointValue;
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        MoveDown();
        //if the object has the tag left it will move left as well as down otherwise it will move right. This is for the obstacles that spawn from the side
        if (!gameObject.CompareTag("Right"))
        {
            if (gameObject.CompareTag("Left"))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameManager.isGameActive)
        {
            if (other.CompareTag("Player"))
            {
                gameManager.lifeCounter = gameManager.lifeCounter - 1;
                Destroy(other.gameObject);
                gameManager.GameOver();
            }
            else
            {
                Destroy(gameObject);
                gameManager.UpdateScore(pointValue);
            }
        }
        
    }
}