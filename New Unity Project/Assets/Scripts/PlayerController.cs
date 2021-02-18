using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce = 10;

    public float gravityMod;

    public bool isOnGround = true; 

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        //&& makes the first part and second part required for the if statement to work
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }
}
