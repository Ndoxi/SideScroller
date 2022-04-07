using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shooting system class.
/// <br></br>
/// <description>
/// Contains references to <b>turret</b> and <b>default ammo</b> game objects. 
/// Turret defines position where shooted ammo will be spawn.
/// Default ammo defines initial ammo.
/// </description>
/// <br></br>
/// One of main parts of shooting system - <b>allAmmo</b> stack, wich defines curent ammo for shooting. 
/// <description>
/// Methods for work with <b>allAmmo</b> stack: 
/// </description>
/// <list type="bullet|number|table">
/// <item>
/// <term>ReadAmmoData</term>
/// <description>Gets last loaded ammo without removing it from stack</description>
/// </item>
///  <item>
/// <term>AddAmmoData</term>
/// <description>Add ammo in stack</description>
/// </item>
///  <item>
/// <term>GetAmmoData</term>
/// <description>Gets last loaded ammo and removes it from stack. 
/// If stack has only 1 ammo left - gets ammo without removing it</description>
/// </item>
/// </list>
/// </summary>
public class ShootingSystem : MonoBehaviour
{
    [Header("Turret object and default ammo")]
    public GameObject turretGO;
    public GameObject defaultAmmo;

    private AmmoTemplate _ammoScript;
    private GameObject _curentAmmoGO;
    private Stack<GameObject> _allAmmo = new Stack<GameObject>();
    private Vector2 _turretPos = Vector2.zero;


    private void Awake()
    {
        AddAmmoData(defaultAmmo);
        LoadNewAmmo(ReadAmmoData());

        MeteorScript.AddAmmoToPlayer += LoadNewAmmo;
    }


    private void OnDestroy()
    {
        MeteorScript.AddAmmoToPlayer -= LoadNewAmmo;
    }


    /// <summary>
    /// Shoot last loaded ammo, wich take place in <b>allAmmo</b> stack.
    /// </summary>
    /// <remarks>
    /// Method shoot ammo only if time passed from last shot <b>greater</b> than current ammo fire rate.   
    /// </remarks>
    public void ShootAmmo()
    {
        if (_allAmmo is null) return;

        _turretPos = turretGO.transform.position;    
        _ammoScript.ShootBullet(_turretPos, Time.time);
    }

    /// <summary>
    /// Gets last loaded ammo without removing it from stack.
    /// </summary>
    /// <returns>Last loaded ammo.</returns>
    public GameObject ReadAmmoData()
    {    
        return _allAmmo.Peek();
    }


    /// <summary>
    /// Add ammo in <b>allAmmo</b> stack
    /// </summary>
    /// <param name="ammoData">Ammo wich will be added to stack</param>
    public void AddAmmoData(GameObject ammoData)
    {
        _allAmmo.Push(ammoData);
    }


    /// <summary>
    /// Gets last loaded ammo and removes it from stack.
    /// </summary>
    /// <returns>Last loaded ammo</returns>
    /// <remarks>
    /// If stack has only 1 ammo left - method gets ammo without removing it.
    /// </remarks>
    public GameObject GetAmmoData()
    {
        if (_allAmmo.Count == 1) return _allAmmo.Peek();

        return _allAmmo.Pop();
    }


    /// <summary>
    /// Loads new ammo for shooting.
    /// </summary>
    /// <param name="newAmmo">New ammo for shooting</param>
    public void LoadNewAmmo(GameObject newAmmo)
    {
        if (_curentAmmoGO != null) { Destroy(_curentAmmoGO); }

        _curentAmmoGO = Instantiate(newAmmo);
        _ammoScript = _curentAmmoGO.GetComponent<AmmoTemplate>();
    }
}