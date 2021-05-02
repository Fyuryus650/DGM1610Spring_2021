using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector3 startPos;
    private float repeatWidth;

    void Start()
    {
        //grabs the start position of the background and divides it by 2
        startPos = gameObject.transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    void Update()
    {
        //uses the division from start to tell when to spawn back at the start making seamless background
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}