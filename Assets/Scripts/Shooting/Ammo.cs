using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// Contain info about ammo, namely: <b>ammo type</b>, <b>ammo data</b> and <b>bullet prefab</b>.
/// </summary>
[Serializable]
public class Ammo
{
    /// <summary>
    /// Ammo type
    /// </summary>
    public GameManagerScript.AmmoTypes ammoType;

    /// <summary>
    /// Info about ammo.
    /// </summary>
    public AmmoData ammoData;

    /// <summary>
    /// Bullet prefab for shooting
    /// </summary>
    public GameObject bulletPrefab;
}
