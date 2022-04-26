using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootAttack : Attack
{
    [Header("Turret")]
    [SerializeField] private GameObject turret;

    [Header("Prefabs")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Attack stats")]
    [SerializeField] private AmmoData bulletStats;


    public override void DoAttack()
    {
        if (turret == null) { return; }

        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = turret.transform.position;

        BossBullet bulletScript = bullet.GetComponent<BossBullet>();

        if (bulletScript == null)
        {
            Destroy(bullet);
            return;
        }

        bulletScript.SetBulletParams(bulletStats.damage, bulletStats.speed);
    }
}
