using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    private float strenght;
    private int powerUpTime = 7;

    public int PowerUpTime
    {
        get { return this.powerUpTime; }
    }
    public bool Ready { get; set; }

    public float Strenght { get; set; }

    public Powerup()
    {
        strenght = 1.0f;
        Ready = true;
    }

    public abstract IEnumerator ActivatePower(GameObject playerObject);
}
