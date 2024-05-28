using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletLifetime = 5f;
    [SerializeField] private float _damage = 30f;

    private void Awake()
    {
        Destroy(gameObject, _bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
  
            enemyHealth.TakeDamage(_damage);
        }

      

        Destroy(gameObject);
    }
}
