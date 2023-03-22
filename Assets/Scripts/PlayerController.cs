using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject powerupIndicator;
    private float speed = 5.0f;
    public bool onGround = true;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public Powerup powerup = null;
    public Powerup Powerup 
    { 
        get { return powerup; }
        set { powerup = value; }
    }

    public bool OnGround 
    { 
        get { return onGround; }
        set { onGround = value; }
    }
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal_point");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0,0.8f,0);

        if(Input.GetKey(KeyCode.Space) && powerup != null && powerup.Ready)
        {
            StartCoroutine(powerup.ActivatePower(gameObject));
        }

        if(transform.position.y < -3)
        {
            GameObject.Find("Spawn manager").GetComponent<SpawnManager>().EndGame();   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            powerup = other.gameObject.GetComponent<Powerup>();
            powerup.gameObject.SetActive(false);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away = (collision.gameObject.transform.position - transform.position).normalized;
            if(powerup != null)
                enemyRb.AddForce(away *  powerup.Strenght, ForceMode.Impulse);
            else
                enemyRb.AddForce(away * 5, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Ground") && !onGround)
        {
            onGround = true;
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            for(int i = 0; i < enemies.Length; i++) 
            {
                Vector3 vec = (enemies[i].transform.position - transform.position + Vector3.up * 15).normalized;
                enemies[i].gameObject.GetComponent<Rigidbody>().AddForce(vec * 10, ForceMode.Impulse);
            }
        }
    }

    public IEnumerator PowerupCountdownRoutine() 
    {
        yield return new WaitForSeconds(7);
        powerupIndicator.gameObject.SetActive(false);
        Destroy(powerup.gameObject);
        powerup = null;
    }
}
