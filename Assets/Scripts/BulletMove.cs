using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    private float speed = 20.0f;
    private float strength = 10.0f;

    // Update is called once per frame
    public void Move(Enemy target)
    {
        Vector3 vec = (target.transform.position - transform.position).normalized;
        gameObject.GetComponent<Rigidbody>().AddForce(vec * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector3 vec = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody>().AddForce(vec * strength, ForceMode.Impulse);
            //TODO: füst
            Destroy(gameObject);
        }
    }
}
