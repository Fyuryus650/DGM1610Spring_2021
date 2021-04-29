using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 50;
    private Rigidbody enemyRB;
    private GameObject player;

    private float yPosition = -30;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed * Time.deltaTime);

        if(transform.position.y < yPosition)
        {
            Destroy(gameObject);
        }
    }
}
