using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public WeaponData weaponData;
    private PlayerHUD playerHUD;

    private void Start()
    {
        playerHUD = GetComponent<PlayerHUD>();
    }

    public int GetCurrentAmmo()
        {
            return weaponData.magazineSize;
        }
   
    public void ReduceAmmo()
    {
        weaponData.magazineSize--;
        playerHUD.UpdateWeaponUI(weaponData);
    }

    public void IncreaseAmmo()
    {
        weaponData.magazineSize += 5;
        playerHUD.UpdateWeaponUI(weaponData);
    }
}
