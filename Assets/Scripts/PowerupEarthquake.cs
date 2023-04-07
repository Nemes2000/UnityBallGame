using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupEarthquake : Powerup
{
    private float jumpPower = 40;
    public PowerupEarthquake() : base() { }

    public override IEnumerator ActivatePower(GameObject playerObject)
    {
        Ready = false;
        Rigidbody rb = playerObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        playerObject.GetComponent<PlayerController>().OnGround = false;
        yield return new WaitForSeconds(0.1f);
        rb.AddForce(Vector3.down * jumpPower * 2, ForceMode.Impulse);
        yield return new WaitForSeconds(2);
        Ready = true;
    }

    public override string ToString()
    {
        return "Earthquake";
    }
}
