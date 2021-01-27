using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Makeup of a variable- Access modifier(public) -> data type(float) -> name(speed)
    private float speed = 20.0f;

    private float turnSpeed = 35.0f;

    private float hInput;

    private float fInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gathers the inputs for the controls
        hInput = Input.GetAxis("Horizontal");
        fInput = Input.GetAxis("Vertical");

        // Makes a vehicle go forward and backwards
        transform.Translate(Vector3.forward * Time.deltaTime * speed * fInput);

        // Makes a vehicle go left and right
        transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime);
    }
}
