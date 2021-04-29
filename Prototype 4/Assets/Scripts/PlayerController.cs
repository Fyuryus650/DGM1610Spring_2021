using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 100;
    private GameObject focalPoint;

    public bool hasPowerup;
    public float powerUpStrength = 16;

    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * Time.deltaTime * forwardInput);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
    }

    //VVThis block of code allows the player to pick up and despawn powerup itemVV
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            Debug.Log("Powerup Collected");

            StartCoroutine(PowerUpCountDownRoutine());

            powerupIndicator.gameObject.SetActive(true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // Get the enemies rigidbody component so we can access its rigid body on collision
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //VVtakes enemy position and subtracts our own position to get the differenceVV
            Vector3 awayFromplayer = (collision.gameObject.transform.position - transform.position);
            //reports collision to console
            Debug.Log("Player has collided with " + collision.gameObject + " with powerup set to " + hasPowerup);
            //on collison kicks back enemy
            enemyRigidbody.AddForce(awayFromplayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);

    }
}
