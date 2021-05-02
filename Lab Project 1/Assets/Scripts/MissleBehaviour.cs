using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleBehaviour : MonoBehaviour
{
    public float speed;
    public ParticleSystem explosion, contrail;
    private Rigidbody missleRB;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        missleRB = GetComponent<Rigidbody>();
        StartCoroutine(MissleLifetime());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        contrail.gameObject.SetActive(true);

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
            yield return new WaitForSeconds(8);
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
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
