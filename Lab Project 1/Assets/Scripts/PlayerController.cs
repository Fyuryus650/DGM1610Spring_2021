using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 15.0f;
    public float acceleration = 1.0f;
    private float hInput, vInput;
    private float missleSpawnOffsetZ = 2f;

    private float xRange = 15.0f;
    private float zRangeMax = 4.7f;
    private float zRangeMin = -2.45f;

    private GameObject player;
    public GameObject misslePrefab;
    private GameManager gameManager;
    private MissleBehaviour missleBehaviour;

    public AudioSource engine;

    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        engine = gameObject.GetComponent<AudioSource>();
        missleBehaviour = GameObject.Find("Missle").GetComponent<MissleBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        GameObject[] missle = GameObject.FindGameObjectsWithTag("Missle");
        int missleCount = missle.Length;

        if (gameManager.isGameActive == true)
        {
            //basic player movement
            transform.Translate(Vector3.right * hInput * turnSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * vInput * acceleration * Time.deltaTime);

            //Creates an airbrake like effect where the plane has an easier time slowing down than it does accelerating helping the illusion of motion
            if (vInput < 0)
            {
                float newAcceleration = 5.0f;
                transform.Translate(Vector3.down * vInput * newAcceleration * Time.deltaTime);
            }
            //fires missles
            if (Input.GetKeyDown(KeyCode.Space) && missleCount < 5)
            {
                Vector3 missleSpawn = new Vector3(player.transform.position.x, player.transform.position.y, (player.transform.position.z + missleSpawnOffsetZ));
                Instantiate(misslePrefab, missleSpawn, misslePrefab.transform.rotation);
            }
          
        }
        //Dictates the boundaries of the player on the screen
        if (transform.position.x > 15)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -15)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z > zRangeMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMax);
        }
        if(transform.position.z < zRangeMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMin);
        }
    }

    public void GameOverDestroy()
    {
        //destroys player once the game is over through the gamemanager script
        Destroy(gameObject);
    }
}
