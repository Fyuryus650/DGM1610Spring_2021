using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleBehaviour : MonoBehaviour
{
    public float speed;
    public ParticleSystem explosion, contrail, secondaryExplosion;
    private Rigidbody missleRB;

    private GameManager gameManager;

    private void Start()
    {
        //Starts life counter for missle and starts the contrail particle system
        StartCoroutine(MissleLifetime());
        contrail.gameObject.SetActive(true);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        GameOver();
    }

    private void GameOver()
    {
        //Destroys left over missles if game ends
        if (gameManager.isGameActive == false)
        {
            DestroyGameObject();
        }
    }

    IEnumerator MissleLifetime()
    {
        {
            //destroys missle after 4 seconds
            yield return new WaitForSeconds(4);
            DestroyGameObject();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Instantiate(secondaryExplosion, gameObject.transform.position, secondaryExplosion.transform.rotation);

        //on collision with an obstacle it will delete the obstacle and the missle.
        if (!other.gameObject.CompareTag("Player"))
        {
            contrail.gameObject.SetActive(false);
            Destroy(other.gameObject);
            DestroyGameObject();
        }
        
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
