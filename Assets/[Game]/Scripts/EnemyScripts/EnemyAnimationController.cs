using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
  
    private Animator animator;
    private NavMeshAgent agent;
    private EnemyAI2 enemyAI;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
        enemyAI = GetComponentInParent<EnemyAI2>();
    }

    private void Update()
    {
        if (enemyAI.player == null)
        {
            Debug.LogWarning("Player reference is not available.");
            return;
        }

        // Update animator parameters based on enemy state
        animator.SetFloat("Speed", agent.velocity.magnitude);
        animator.SetBool("IsAttacking", enemyAI.playerInAttackRange);
    }
}

