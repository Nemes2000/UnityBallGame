using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupPower : Powerup
{
    public PowerupPower() : base()
    {
        Strenght = 15;
    }

    public override IEnumerator ActivatePower(GameObject playerObject) { yield return null; }
}
