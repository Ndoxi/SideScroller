using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BossScript : EnemyTemplate
{

    private void ShootAttack()
    {

    }


    private void LaserAttack()
    {

    }


    private void RamAttack()
    {

    }


    public override void Death()
    {
        Destroy(gameObject);
    }
}
