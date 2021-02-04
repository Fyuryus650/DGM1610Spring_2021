using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;

    private float hInput;

    private float xRange = 20.5f;

    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");

        //If statements to indicate barriers to the player. Player ill not be able to move past these boundaries\
        //If the player reaches the xRange the player will not move past it
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Launch the projectile, 3 parts, What is being instantiated, where its being instantiated, what orientation the object is in
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }


        //normal movement on the x axis
        transform.Translate(Vector3.right * hInput * speed * Time.deltaTime);
        
    }
}
