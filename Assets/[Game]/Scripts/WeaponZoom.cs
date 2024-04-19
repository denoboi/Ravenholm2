

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
   
    public Camera cam;
    public float minFOV = 45;
    [SerializeField]
    private float t = 0.1f;

    RigidbodyFirstPersonController fpsController;
    [SerializeField]
    float minMouseSens = .5f;
    [SerializeField]
    float maxMouseSens = 2f;

    bool isAiming = false;
    

    void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            isAiming = true;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, minFOV, t);
            fpsController.mouseLook.XSensitivity = minMouseSens;
            fpsController.mouseLook.YSensitivity = minMouseSens;
                 
        }
        if(Input.GetMouseButtonUp(1))
        {
            isAiming = false;
            
        }
        if(isAiming == false && cam.fieldOfView !=60)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 0.05f); 
            fpsController.mouseLook.XSensitivity = maxMouseSens;
            fpsController.mouseLook.YSensitivity = maxMouseSens;
        }
    }
}
