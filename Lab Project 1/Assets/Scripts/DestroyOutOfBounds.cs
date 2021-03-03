using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
