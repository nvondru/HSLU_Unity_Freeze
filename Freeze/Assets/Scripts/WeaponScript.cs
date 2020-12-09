using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float chargeUpTimeMax = 2f;
    [SerializeField]
    private float chargeUpMultiplier = 5f;

    private float chargeUpTimeStart;
    private float chargeUpTimeCurrent;
    private bool canShoot = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            chargeUpTimeStart = Time.time;
            canShoot = true;
        }
        if ((Input.GetButtonUp("Fire1") || (Time.time - chargeUpTimeStart) >= chargeUpTimeMax) && canShoot)
        {            
            Shoot();
        }
    }

    private void Shoot()
    {
        chargeUpTimeCurrent = Time.time - chargeUpTimeStart;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.localScale *= ((chargeUpTimeCurrent * chargeUpMultiplier) + 1);
        canShoot = false;
    }
}
