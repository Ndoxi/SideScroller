using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
    [Header("Spawner")]
    public GameObject spawner;
    public enum AmmoTypes { DEFAULT, TRIPLE };

    [Header("All ammo data for this level")]
    public AllAmmoData allAmmoData;
    private Dictionary<AmmoTypes, Ammo> _allAmmoDictionary = new Dictionary<AmmoTypes, Ammo>();


    private void Awake()
    {
        foreach (Ammo ammo in allAmmoData.ammoList)
        {
            if (!_allAmmoDictionary.ContainsKey(ammo.ammoType))
            {
                _allAmmoDictionary.Add(ammo.ammoType, ammo);
            }
        }
    }


    /// <summary>
    /// Set ammo data
    /// </summary>
    public Ammo AmmoData
    {
        set 
        {
            if (!_allAmmoDictionary.ContainsKey(value.ammoType))
            {
                _allAmmoDictionary.Add(value.ammoType, value);
            }
        }
    }


    /// <summary>
    /// Get ammo data my <b>AmmoType</b>
    /// </summary>
    /// <param name="ammoType">Ammo</param>
    /// <returns></returns>
    private Ammo GetAmmoData(AmmoTypes ammoType)
    {
        return _allAmmoDictionary[ammoType];
    }


    /// <summary>
    /// Get ammo for shooting 
    /// </summary>
    /// <param name="ammoType"></param>
    /// <returns></returns>
    public AmmoTemplate GetAmmoForShooting(AmmoTypes ammoType)
    {
        Ammo ammo = GetAmmoData(ammoType);

        switch (ammoType) 
        {
            case AmmoTypes.DEFAULT:
                {
                    return new DefaultAmmoScript(ammo.bulletPrefab, ammo.ammoData);
                }
            case AmmoTypes.TRIPLE:
                {
                    return new TrippleAmmoScript(ammo.bulletPrefab, ammo.ammoData);
                }

        }

        return new DefaultAmmoScript(ammo.bulletPrefab, ammo.ammoData);
    }
}
