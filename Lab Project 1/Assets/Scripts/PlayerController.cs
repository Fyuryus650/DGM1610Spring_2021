using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 15.0f;
    public float acceleration = 1.0f;
    public float hInput;
    public float vInput;
    public float missleSpawnOffsetZ = 2f;

    private float xRange = 15.0f;
    private float zRangeMax = 4.7f;
    private float zRangeMin = -2.45f;

    private GameObject player;
    public GameObject misslePrefab;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (gameManager.isGameActive == true)
        {
            //basic player movement
            transform.Translate(Vector3.right * hInput * turnSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * vInput * acceleration * Time.deltaTime);

            //Creates an airbrake like effect where the plane has an easier time slowing down than it does accelerating
            if (vInput < 0)
            {
                float newAcceleration = 5.0f;
                transform.Translate(Vector3.forward * vInput * newAcceleration * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 missleSpawn = new Vector3(player.transform.position.x, player.transform.position.y, (player.transform.position.z + missleSpawnOffsetZ));
                Instantiate(misslePrefab, missleSpawn, misslePrefab.transform.rotation);
            }
        }
        //Dictates the boundaries of the player on the screen
        if(transform.position.x > 15)
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
}
