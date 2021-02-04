using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    public float topBound = 35.0f;
    public float bottomeBound = -15.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 2);   <--- this is how to destroy with time
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < bottomeBound)
        {
            Destroy(gameObject);
        }
    }
}
