using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootAttack : Attack
{
    [Header("Turret")]
    [SerializeField] private List<GameObject> turrets;

    [Header("Prefabs")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Attack stats")]
    [SerializeField] private AmmoData bulletStats;

    [Header("Sound effects")]
    [SerializeField] private AudioClip shootSound;

    private IEnumerator shooting;


    public override void DoAttack()
    {
        if (turrets.Count == 0) { return; }

        GameObject bullet = Instantiate(bulletPrefab);
        GameObject randomTurret = GetRandomTurret();
        bullet.transform.position = randomTurret.transform.position;

        BossBullet bulletScript = bullet.GetComponent<BossBullet>();

        if (bulletScript == null)
        {
            Destroy(bullet);
            return;
        }

        bulletScript.SetBulletParams(bulletStats.damage, bulletStats.speed);

        SoundManager.PlaySoundEffect(shootSound);
    }


    private GameObject GetRandomTurret()
    {
        int max = turrets.Count;

        int randomIndex = Random.Range(0, max);

        Debug.Log($"Turret {randomIndex}");

        return turrets[randomIndex];
    }


    public void StartShooting()
    {
        shooting = StartShootingCoruotine();
        StartCoroutine(shooting);
    }


    public void StopShooting()
    {
        if (shooting == null) { return; }
        StopCoroutine(shooting);
    }


    IEnumerator StartShootingCoruotine()
    {
        while (true)
        {
            DoAttack();

            yield return new WaitForSeconds(bulletStats.fireRate);
        }
    }
}
