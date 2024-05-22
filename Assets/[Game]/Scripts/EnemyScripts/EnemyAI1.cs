using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI1 : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float damage = 20f;

    NavMeshAgent navMeshAgent;

    // enemy kendisinden uzakta oldugunu anlamasi icin, infinity yapmazsak default 0 oluyor bu da hemen ustunde ya da yaninda gibi, o da sacmaliyor.
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        EventManager.OnDamageTaken.AddListener(OnDamageTaken);
    }
    private void OnDisable()
    {
        EventManager.OnDamageTaken.RemoveListener(OnDamageTaken);
    }



    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
            
        }

        if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;

        }

        else
        {
            isProvoked = false;
            GetComponent<Animator>().SetBool("Idle", true);
        }


    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack", false);
        
        navMeshAgent.SetDestination(target.position);
    }    

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        
        Debug.Log(name + "has seeked and is destroying" + target.name);
        //if (target == null) return;

        //target.GetComponent<PlayerHealth>().TakeDamage(damage);

    }

    void EngageTarget()
        {
            if (distanceToTarget >= navMeshAgent.stoppingDistance)
            {
                ChaseTarget();
            }

            else if (distanceToTarget <= navMeshAgent.stoppingDistance)
            {
                AttackTarget();

            }
        }

    void OnDrawGizmosSelected()
    {
     // Display the chase radius when selected
     Gizmos.color = Color.red;
     Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void OnDamageTaken()
    {
        isProvoked = true;
    }

}


