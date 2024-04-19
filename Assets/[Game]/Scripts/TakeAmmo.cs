using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAmmo : MonoBehaviour
{
    bool isAmmoTaken;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<Ammo>().IncreaseAmmo();
            
        }
        
    }
}
