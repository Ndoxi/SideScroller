using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleAmmoScript : AmmoTemplate
{
    public TrippleAmmoScript(GameObject bulletPrefab, AmmoData ammoData)
    {
        this.bulletPrefab = bulletPrefab;
        this.ammoData = ammoData;
    }


    public override void ShootBullet(Vector2 turetPos, float time, int damageMult = 1, float speedMult = 1, float fireRateMult = 1)
    {
        if (_nextFire > time) { return; }

        _nextFire = time + ammoData.fireRate / fireRateMult;

        GameObject bullet1 = Instantiate(bulletPrefab);
        bullet1.transform.position = turetPos;
        Bullet bulletScipt1 = bullet1.GetComponent<Bullet>();
        bulletScipt1.SetBuletParams(ammoData.damage * damageMult, ammoData.speed * speedMult, 0, 0);

        GameObject bullet2 = Instantiate(bulletPrefab);
        bullet2.transform.position = turetPos;
        Bullet bulletScipt2 = bullet2.GetComponent<Bullet>();
        bulletScipt2.SetBuletParams(ammoData.damage * damageMult, ammoData.speed * speedMult, 33, 33);

        GameObject bullet3 = Instantiate(bulletPrefab);
        bullet3.transform.position = turetPos;
        Bullet bulletScipt3 = bullet3.GetComponent<Bullet>();
        bulletScipt3.SetBuletParams(ammoData.damage * damageMult, ammoData.speed * speedMult, -33, -33);

        //bullets lifetime
        Destroy(bullet1, 0.6f);
        Destroy(bullet2, 0.6f);
        Destroy(bullet3, 0.6f);
    }
}
