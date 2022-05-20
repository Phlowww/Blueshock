using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAimWeapon : MonoBehaviour
{
    //public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    public float fireRate = 0.35f;
    private float fireTime = 0f;
    private bool canFire = true;

    private Transform aimTransform;
    private Transform aimGunEndPointTransform;
    private Animator aimAnimator;


    public GameObject laserBall;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponentInChildren<Animator>();
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");
    }

    private void Update()
    {
        HandleAiming();
        HandleShooting();
        CheckCanFire();
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);


        Vector3 aimLocalScale = Vector3.one;
        if(angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;
        }
        else
        {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;
    }
    private void HandleShooting()
    {
        if (Input.GetMouseButton(0) && canFire == true)
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

            aimAnimator.SetTrigger("Shoot");
            /*OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition,
            });*/

            SpawnLaserball();
            fireTime = fireRate;
        }


    }

    protected void CheckCanFire()
    {
        fireTime -= Time.deltaTime;

        if (fireTime <= 0)
        {
            canFire = true;
            fireTime = 0;
        }
        else
        {
            canFire = false;
        }
    }
    


    private void SpawnLaserball()
    {
        GameObject clone = Instantiate(laserBall, aimGunEndPointTransform.position, aimGunEndPointTransform.rotation);
    }
}
