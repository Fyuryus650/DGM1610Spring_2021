using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 80.0f;
    public float hInput;
    private float xRange = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");

        if(transform.position.x > 15)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -15)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.right * hInput * turnSpeed * Time.deltaTime);

    }
}
