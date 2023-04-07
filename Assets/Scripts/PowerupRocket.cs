using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRocket : Powerup
{
    [SerializeField]
    private GameObject bullet;
    public override IEnumerator ActivatePower(GameObject playerObject)
    {
        Ready = false;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        for(int i = 0; i < enemies.Length; i++)
        {
            Vector3 enemyPos = (enemies[i].gameObject.transform.position - playerObject.transform.position).normalized;
            Vector3 dif = new Vector3(enemyPos.x * 1.5f, enemyPos.y, enemyPos.z * 1.5f);
            var newBullet = Instantiate(bullet, playerObject.transform.position + dif, bullet.transform.rotation);
            newBullet.GetComponent<BulletMove>().Move(enemies[i]);
        }
        yield return new WaitForSeconds(2);  
        Ready = true;
    }

    public override string ToString()
    {
        return "Rocket";
    }

}
