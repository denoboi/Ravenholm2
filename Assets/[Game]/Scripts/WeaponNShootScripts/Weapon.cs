using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] Camera fpCamera;
    [SerializeField] Camera muzzleCam;
    [SerializeField] float damage = 20f;

    [SerializeField] ParticleSystem dash; //maybe change the name
    [SerializeField] GameObject hitFx;

    [SerializeField] GameObject fireball;
    [SerializeField] float shootForce = 5f;
    private PlayerHUD playerHUD;

    public Vector3 smoothAds;

    public Ammo ammoSlot;
    public bool ammoAvailable = true;
    public bool isAiming = false;
    public Vector3 aimDownSight;
    public Vector3 hipFire;


    [SerializeField]
    private float aimspeed = 1500f;
    
    private void Start()
    {
        playerHUD = GetComponentInParent<PlayerHUD>();
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Shoot();
        //}

        if (Input.GetMouseButtonDown(1))
        {
            smoothAds = transform.localPosition;
            isAiming = true;
        }
        if (Input.GetMouseButton(1))
        //0, 0.17,0.235
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimDownSight, aimspeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
        }
        if (!isAiming && transform.localPosition != hipFire)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, hipFire, 7f * Time.deltaTime);
        }
    }

    //private void Shoot()
    //{
    //    if (ammoSlot.GetCurrentAmmo() > 0)
    //    {
    //        ammoAvailable = true;
    //    }

    //    if (ammoAvailable)
    //    {
    //        ProcessRaycast();
    //        dash.Play();
    //        ammoSlot.ReduceAmmo();
    //        //playerHUD.UpdateWeaponUI();
    //    }

    //    if (ammoSlot.GetCurrentAmmo() <= 0)
    //    {
    //        ammoAvailable = false;
    //    }


    //}

    //public void ProcessRaycast()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(muzzleCam.transform.position, muzzleCam.transform.forward, out hit, range))
    //    {
    //        Debug.Log("I hit this thing:" + hit.transform.name);
    //        CreateHitFX(hit);
    //        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();


    //        if (target == null) return; //enemy yerine diger objelere ates edersem.

    //        target.TakeDamage(damage); // asil oldurecek olan bu.
    //    }

    //}

    //private void CreateHitFX(RaycastHit hit)
    //{
    //    GameObject impact = Instantiate(hitFx, hit.point, Quaternion.LookRotation(hit.normal));
    //    Destroy(impact, 2);
    //}
}
