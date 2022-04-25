using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossBullet : MonoBehaviour
{
    private int bulletDamage;
    private float bulletSpeed;

    private void Update()
    {
        if (bulletSpeed == 0) { return; }

        Vector2 newPos;
        newPos.x = gameObject.transform.position.x - bulletSpeed * Time.deltaTime;
        newPos.y = gameObject.transform.position.y;

        gameObject.transform.position = newPos;
    }


    public void SetBulletParams(int bulletDamage, float bulletSpeed)
    {
        this.bulletDamage = bulletDamage;
        this.bulletSpeed = bulletSpeed;
    }
}
