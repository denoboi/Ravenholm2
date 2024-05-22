using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;
    
    
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        EventManager.OnDamageTaken.Invoke();
        hitPoints -= damage; //ne kadar damage ise o kadar health azalacak.
        if (hitPoints <= 0)
        {
            Destroy(gameObject);

        }
    

}
    

}
