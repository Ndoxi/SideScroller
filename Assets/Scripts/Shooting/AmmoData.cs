using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Contains ammo data, such as bullets damage, speed and damage.
/// </summary>
[CreateAssetMenu(menuName = "GameStructs/AmmoData")]
public class AmmoData : ScriptableObject
{
    public int damage;
    public float speed;
    public float fireRate;
}
