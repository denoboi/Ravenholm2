using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects /Weapons", order = 1)]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float fireRate;
    public float range;
    public int magazineSize;
    public int magazineCount;
    public WeaponType weaponType;
    public GameObject prefab;
    public Sprite icon;

}

public enum WeaponType { Melee, Pistol, AR, Shotgun, Sniper };
