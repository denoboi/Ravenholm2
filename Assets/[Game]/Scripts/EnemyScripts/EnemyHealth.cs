using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float _hP = 100f;
    
    
    public void TakeDamage(float damage)
    {
        
        _hP -= damage; 
        if (_hP <= 0)
        {
            Destroy(gameObject);

        }
    

}



}
