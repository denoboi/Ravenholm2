using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints;

    private bool isDead;
    public bool IsDead {  get { return isDead; } }
   

    public void TakeDamage(float damage)
    {
        if(isDead) return;

        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            isDead = true;
            GetComponent<DeathHandler>().HandleDeath();   
            Debug.Log("You dead, my glip glop");
        }
    }

    private void Update()
    {
        if(isDead) 
          return;

        CalculatePosition();
    }

    private void CalculatePosition()
    {
        if(gameObject.transform.position.y < -50)
        {
            isDead=true;
            GetComponent<DeathHandler>().HandleDeath();
        }
            
        
    }

}
