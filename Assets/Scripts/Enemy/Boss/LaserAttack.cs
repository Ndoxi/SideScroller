using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserAttack : Attack
{
    [Header("Turret")]
    [SerializeField] private GameObject turret;

    [Header("Prefabs")]
    [SerializeField] private GameObject laserPrefab;

    [Header("Attack stats")]
    [SerializeField] private AmmoData laserStats;


    public override void DoAttack()
    {
        if (turret == null) { return; }

        GameObject laser = Instantiate(laserPrefab, turret.transform);
        laser.transform.position = turret.transform.position;

        LaserScript laserScript = laser.GetComponent<LaserScript>();
        if (laserScript == null) { return; }

        laserScript.SetLaserDamage(laserStats.damage);
    }
}
