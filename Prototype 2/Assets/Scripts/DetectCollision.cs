using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy this object that the script is attached to
        Destroy(gameObject);
        //Destroy other object that collided with the scripted object
        Destroy(other.gameObject);
    }
}
