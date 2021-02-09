using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    public float topBound = 35.0f;
    public float bottomBound = -15.0f;

   

    //Destroy(gameObject, 2);   <--- this is how to destroy with time
  

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < bottomBound)
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }
}
