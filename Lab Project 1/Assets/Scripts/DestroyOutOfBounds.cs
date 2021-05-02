using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Boundaries for obstacles
    void Update()
    {
        if(transform.position.x > 22)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < -22)
        {
            Destroy(gameObject);
        }
        if(transform.position.z > 23)
        {
            Destroy(gameObject);
        }
        if(transform.position.z < -7)
        {
            Destroy(gameObject);
        }
    }
}
