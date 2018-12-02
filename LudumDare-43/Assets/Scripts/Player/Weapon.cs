using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform shootingPoint;
    public Transform shootingPointleft;
    public Transform shootingPointfarleft;
    public Transform shootingPointright;
    public Transform shootingPointfarright;
    public Transform BulletTrailPrefab;
    public float fireRate = 0;
    public float damage = 10;
    public int ammoCapcity = 10;
    public int currentAmmo = 10;
    public float reloadTime = 2f;

    private float reloadCounter;
    private bool isReloading;
    public int weaponLevel = 0;
   
    private bool justShot;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("r"))
        {
            Reload();
        }

        if (Input.GetButton("Fire1"))
        {
            if (!justShot)
            {
                Shoot();
            }
        }

        if (isReloading)    
        {
            reloadCounter += Time.deltaTime;
            if (reloadCounter >= reloadTime)
            {
                reloadCounter = 0f;
                currentAmmo = ammoCapcity;
                isReloading = false;
            }
        }

        if (justShot)
        {
            fireRate += Time.deltaTime;
            if (fireRate >= 0.5)
            {
                fireRate = 0f;
                justShot = false;
            }
        }
    }

    void Shoot()
    {
        if (!isReloading && currentAmmo > 0)
        {
            if (weaponLevel == 0) Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
            if (weaponLevel == 1)
            {
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
            }
            if (weaponLevel == 2)
            {
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointright.position, shootingPoint.rotation);
            }
            if (weaponLevel == 3)
            {
                Instantiate(BulletTrailPrefab, shootingPointfarleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointright.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointfarright.position, shootingPoint.rotation);
            }
            currentAmmo--;
            justShot = true;
        }
        
    }

    void Reload()
    {
        if (currentAmmo < 10)
        {
            isReloading = true;
        }
    }
}
