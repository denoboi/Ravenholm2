using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] Camera fpCamera;
    [SerializeField] Camera muzzleCam;
    [SerializeField] float damage = 20f;
   
    [SerializeField] ParticleSystem dash;
    
    [SerializeField] GameObject fireball;
    [SerializeField] float shootForce = 5f;

    [SerializeField] public Vector3 smoothAds;
    
    [SerializeField] public Ammo ammoSlot;
    public bool ammoAvailable = true;
    bool isAiming = false;
    public Vector3 aimDownSight;
    public Vector3 hipFire;
    
     
    [SerializeField]
    float aimspeed = 1500f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
         if(Input.GetMouseButtonDown(0))       //if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
           

            //fireball.Play();
            GameObject projectile = (GameObject)Instantiate(fireball, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(fireball.transform.forward * shootForce); 
            
        }

       

        if(Input.GetMouseButtonDown(1))
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
        if(isAiming == false && transform.localPosition != hipFire)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, hipFire, 7f * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            ammoAvailable = true;
        }

        if (ammoAvailable == true)
        {
            ProcessRaycast();
            dash.Play();
            ammoSlot.ReduceAmmo();
                     
        }

        if (ammoSlot.GetCurrentAmmo() <= 0 )
        {
            ammoAvailable = false;
        }

        

    }
        
     
    public void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(muzzleCam.transform.position, muzzleCam.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing:" + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            
            if (target == null) return; //enemy yerine diger objelere ates edersem.
            
            target.TakeDamage(damage); // asil oldurecek olan bu.
            
        }
       
    }

  

        
}
