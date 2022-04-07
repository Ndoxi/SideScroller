using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "GameStructs/AmmoForCurentLevel")]
public class AllAmmoData : ScriptableObject
{
    [Header("Ammo data and bullet prefab")]
    public List<Ammo> ammoList;
}
