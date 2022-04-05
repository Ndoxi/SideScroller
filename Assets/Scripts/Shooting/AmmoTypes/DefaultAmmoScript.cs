using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultAmmoScript : AmmoTemplate
{
    public DefaultAmmoScript(GameObject bulletPrefab, AmmoData ammoData)
    {
        this.bulletPrefab = bulletPrefab;
        this.ammoData = ammoData;
    }    


    public override void ShootBullet(Vector2 turetPos, float time, int damageMult = 1, float speedMult = 1, float fireRateMult = 1)
    {
        if (_nextFire > time) { return; }
        
        _nextFire = time + ammoData.fireRate / fireRateMult;

        GameObject go = Instantiate(bulletPrefab);
        go.transform.position = turetPos;
        Bullet _bullet = go.GetComponent<Bullet>();
        _bullet.SetBuletParams(ammoData.damage * damageMult, ammoData.speed * speedMult, 0, 0);
    }
}
