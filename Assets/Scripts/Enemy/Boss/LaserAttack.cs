using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : Attack
{
    [Header("Turret")]
    [SerializeField] private GameObject turret;

    [Header("Prefabs")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Attack stats")]
    [SerializeField] private AmmoData bulletStats;


    public override void DoAttack()
    {

    }
}
