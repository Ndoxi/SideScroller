using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "GameStructs/AmmoForCurentLevel")]
public class AllAmmoData : ScriptableObject
{
    public List<GameObject> ammoForCurentLevel;
}
