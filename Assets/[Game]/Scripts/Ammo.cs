using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    public int ammoAmount  ;

    public int GetCurrentAmmo()
        {
            return ammoAmount;
        }
   
    public void ReduceAmmo()
    {
        ammoAmount--;
    }

    public void IncreaseAmmo()
    {
        ammoAmount += 5;
    }
}
