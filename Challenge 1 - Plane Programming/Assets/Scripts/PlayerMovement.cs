using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float vInput = 10.0f;
    private float speed = 20.0f;
    private float turnSpeed = 65.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gets input from controller
        vInput = Input.GetAxis("Vertical");
        // Creates speed of plane
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        transform.Rotate(Vector3.right * vInput * -1 * Time.deltaTime * turnSpeed);

    }
}
