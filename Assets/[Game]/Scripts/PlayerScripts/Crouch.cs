using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class Crouch : MonoBehaviour
    {
        private RigidbodyFirstPersonController _rbFPSController;
        public RigidbodyFirstPersonController RbFPSController => _rbFPSController ??= GetComponent<RigidbodyFirstPersonController>();

        private Rigidbody _rb;
        private CapsuleCollider _capsuleCollider;

        private float _originalHeight;
        [SerializeField] private float _reducedHeight;
        

        public bool IsCrouching;
       
        public float crouchSpeedModifier = 0.5f; // speed when crouched

        private bool isCrouching = false;


        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _originalHeight = _capsuleCollider.height;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Crouching();
            }
            else if (Input.GetKeyUp(KeyCode.C))
            {
                UnCrouch();    
            }
        }

        private void Crouching()
        {
            if (!IsCrouching)
            {
                IsCrouching = true;
                RbFPSController.m_IsGrounded = true;
                _capsuleCollider.height = _reducedHeight;

                AdjustForwardSpeed(crouchSpeedModifier);         
            }
        }

        private void UnCrouch()
        {
            if (IsCrouching)
            IsCrouching = false;
            _capsuleCollider.height = _originalHeight;

            AdjustForwardSpeed(1f / crouchSpeedModifier);
            
        }

        private void AdjustForwardSpeed(float modifier)
        {
            RbFPSController.movementSettings.ForwardSpeed *= modifier;
            RbFPSController.movementSettings.CurrentTargetSpeed *= modifier;
        }



    }



}

