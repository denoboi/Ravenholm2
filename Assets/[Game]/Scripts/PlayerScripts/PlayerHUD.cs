using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private WeaponUI weaponUI;

    public void UpdateWeaponUI(WeaponData weaponData)
    {
        weaponUI.UpdateInfo(weaponData.icon, weaponData.magazineSize, weaponData.magazineCount);
    }
}
