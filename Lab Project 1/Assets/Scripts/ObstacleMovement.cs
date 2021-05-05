using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public int lifeLostValue = -1;
    public int pointValue;
    private GameManager gameManager;
    public ParticleSystem explosion, secondaryExplosion;

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
        //moves the object towards the direction of the player
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void MoveDown()
    {
        //general movement code for moving downwards towards the bottom of screen
        if(gameObject.CompareTag("Top"))
        {
            //some imported models were created weird, adjusted with the code
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive == true)
        {
            //if the obstacle hits a player
            if (other.CompareTag("Player"))
            {
                //updates the Life counter in the Game manager
                gameManager.UpdateLife(lifeLostValue);
                Destroy(gameObject);
                Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
                Instantiate(secondaryExplosion, gameObject.transform.position, secondaryExplosion.transform.rotation);
                //checks if player is out of lives and declares Game over if lives are at 0
                gameManager.GameOver();
            }
            else
            {
                //if the object is destroyed by any other means it adds the score to the player
                gameManager.UpdateScore(pointValue);
            }
        }
    }
}