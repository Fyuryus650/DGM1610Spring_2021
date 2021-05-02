using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleBehaviour : MonoBehaviour
{
    public float speed;
    public ParticleSystem explosion, contrail, secondaryExplosion;
    private Rigidbody missleRB;

    private GameManager gameManager;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        //sets effect for missle
        contrail.gameObject.SetActive(true);
        StartCoroutine(MissleLifetime());

        //Destroys left over missles if game ends
        if (!gameManager.isGameActive)
        {
            Debug.Log("GameOver");
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
        //on collision with an obstacle it will delete the obstacle and the missle.
        if (!other.gameObject.CompareTag("Player"))
        {
            contrail.gameObject.SetActive(false);
            Destroy(other.gameObject);
            DestroyGameObject();
        }
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Instantiate(secondaryExplosion, gameObject.transform.position, secondaryExplosion.transform.rotation);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
