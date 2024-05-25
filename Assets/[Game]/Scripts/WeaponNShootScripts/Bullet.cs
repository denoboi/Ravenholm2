using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletLifetime = 5f;

    //private void Awake()
    //{
    //    Destroy(gameObject, _bulletLifetime) ;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        //Destroy(gameObject);
    }
}
